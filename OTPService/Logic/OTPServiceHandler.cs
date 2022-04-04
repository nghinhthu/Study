using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MSA.FW.BaseApp;
using MSA.FW.Validation;
using OTPService.DataHandler;
using OTPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Logic
{
    public class OTPServiceHandler : IOTPServiceHandler
    {
        ILogger<OTPServiceHandler> logger;
        ApplicationConfiguration appconfig;
        #region constructor

        public OTPServiceHandler(IOptions<ApplicationConfiguration> option, IOTPDataHandler _otpDataHander,
           ILogger<OTPServiceHandler> _logger)
        {
            appconfig = option.Value;
            OTPConfig = appconfig.DefaultConfig;
            logger = _logger;
            DataHandler = _otpDataHander;
        }
        #endregion
        IOTPDataHandler otpDataHander;
        OTPConfiguration otpConfig;
        public OTPConfiguration OTPConfig { get => otpConfig; set => otpConfig = value; }
        public IOTPDataHandler DataHandler { get => otpDataHander; set => otpDataHander = value; }
        //public IOTPDataHandler DataHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Get OTPCode cho client
        /// 1. kiem tra request co hop le ve fieldName va value
        /// 2 kiem tra xem request co hop le ve mat session 
        /// 3 kiem tra xem request co hop le ve mat sequence
        /// 4 sinh ra OTP code va luu vao Database
        /// 5. end
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BOProcessResult> GetOTPCode(RequestOTP request)
        {
            BOProcessResult processResult = new BOProcessResult();


            RequestOTPData lastData;
            OTPResult otpResult = new OTPResult();


            //BuildConfiguration(request.TCodeKey);==> ham nay xay dung lai OTPconfig = cach doc OTPConfig tu CSDL
            //Sau do Re-load OTPConfigData vao trong bien OTPConfig


            //request.OTPConfig = OTPConfig;

            if (!request.IsValid)
            {
                processResult.Errors = request.GetAllError();
                LogError(processResult.Errors);
                return processResult;
            }

            #region check business rule base on OTP configuration



            //thoi gian de xet duyet trong khoang TG 12g

            int dataRange = OTPConfig.RequestDataRange;

            DateTime allowLastRequestDateTime = DateTime.Now.AddHours(dataRange * -1);

            //2.lay data ra de kiem tra session va sequence
            BOProcessResult dataProcessResult = await DataHandler.GetLastOTPData(request.TCodeKey, request.RequesterID, allowLastRequestDateTime);
            if (dataProcessResult.Errors.Count == 0)
            {
                lastData = (RequestOTPData)dataProcessResult.Content;
            }
            else
            {
                //lỗi kg doc dc dữ liệu
                LogError(dataProcessResult.Errors);
                processResult.Errors.AddRange(processResult.Errors);
                LogError(processResult.Errors);
                return processResult;
            }
            //3. lastData=null, kg ton tai record nao ca==> new session
            if (lastData == null)
            {
                otpResult = GenerateOTPCode(request, 0);
                //save request
                processResult.Content = otpResult;

            }
            else
            {
                //4.lastdata is in the same session

                //============ rule 1  ==================
                //Request nhan dc phải trong khoảng TG cho phép, kg dc quá lâu
                //thi du nhu so voi TG request gan nhat la 100second=>
                //neu vi pham client/user bat buoc phai khoi tao session moi
                //============================================
                if (lastData.SessionID == request.SessionID)
                {
                    int maxSecondsBetweenRequest = OTPConfig.MaxSecondsBWRequest;
                    if (maxSecondsBetweenRequest > 0)
                    {
                        double totalSeconds = (lastData.RequestDateTime - request.RequestDateTime).TotalSeconds;
                        if (totalSeconds >= maxSecondsBetweenRequest)
                        {
                            processResult.Content = null;
                            MSAError error = new MSAError();
                            error.Property = "generic";
                            error.Description = "Please start new transction";
                            error.ErrorCode = "RequestTimeIsInvalid";
                            error.RuleName = "RequestTimeTooLong";
                            processResult.Errors.Add(error);
                            LogError(processResult.Errors);
                            return processResult;

                        }
                    }
                    //rule2: kiem tra so lan request trong 1 session
                    //neu lan request cuoi cung da cham ngưỡng max sequence thì
                    // restart new session
                    if (lastData.Sequence >= OTPConfig.MaxSequence)
                    {

                        //error over max sequence by session
                        processResult.Content = null;
                        MSAError error = new MSAError();
                        error.Property = "generic";
                        error.Description = "Too many request in transaction";
                        error.ErrorCode = "TooManyRequestBySession";
                        error.RuleName = "RequestInSession";
                        processResult.Errors.Add(error);
                        LogError(processResult.Errors);
                        return processResult;
                    }

                    otpResult = GenerateOTPCode(request, lastData.Sequence);
                    processResult.Content = otpResult;
                }
                //3. last data exist but in different session
                else
                {
                    if (OTPConfig.MaxSessionLimit > 0)
                    {
                        //requesttime ở lan tiep theo so sanh voi session truoc phai > config value
                        TimeSpan ts = request.RequestDateTime - lastData.RequestDateTime;
                        double minutes = ts.TotalMinutes;
                        //requesttime ở lan tiep theo so sanh voi session truoc phai > config value
                        if (minutes > OTPConfig.MaxSessionLimit)
                        {
                            otpResult = GenerateOTPCode(request, 0);
                        }
                        else
                        {
                            //error over max session per interval of session
                            DateTime allowRequestTime = lastData.RequestDateTime.AddMinutes(OTPConfig.MaxSessionLimit);
                            processResult.Content = null;
                            MSAError error = new MSAError();
                            error.Property = "generic";
                            error.Description = string.Format("please wait until {0} ", allowRequestTime);
                            error.ErrorCode = "MaxSessionLimit";
                            error.RuleName = "MaxSessionLimitRule";

                            processResult.Errors.Add(error);
                            LogError(processResult.Errors);
                            return processResult;
                        }
                    }
                    else
                    {
                        otpResult = GenerateOTPCode(request, 0);
                    }
                }

            }
            #endregion
            processResult.Content = otpResult;
            //4. sinh ra OTP code va luu vao Database
            BOProcessResult saveProcessResult = await DataHandler.SaveRequest(request, otpResult);
            if (saveProcessResult.Errors.Count > 0)
            {
                processResult.Content = null;
                processResult.Errors.AddRange(saveProcessResult.Errors);
                LogError(processResult.Errors);
                return processResult;
            }

            return processResult;
        }

        private void LogError(List<MSAError> errors)
        {
            if (logger == null)
            {
                return;
            }
            foreach (var item in errors)
            {
                logger.LogError(item.Description, item.Property, item.Property);
            }
        }





        /// <summary>
        /// sinh ra OTP theo yc
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private OTPResult GenerateOTPCode(RequestOTP request, int currentSequence)
        {
            string otpCode = DateTime.Now.ToString("hhmmss");
            DateTime generateDateTime = DateTime.Now;
            int expiredIn = OTPConfig.ExpiredIn;
            DateTime expiredDateTime = generateDateTime.AddSeconds(expiredIn);

            OTPResult result = new OTPResult()
            {
                GenerateDateTime = generateDateTime,
                ID = Guid.NewGuid().ToString(),
                Sequence = currentSequence + 1,
                SessionID = request.SessionID,
                OTPCode = otpCode,
                ExpiredIn = expiredIn,
                ExpiredDateTime = expiredDateTime
            };
            return result;
        }



        /// <summary>
        /// Tra ve cho client biet la OTPCode nhap vao giao dien (SessionID) co dung kg,
        /// sau do moi xu ly tiep (ex: neu dung thi save register data into database)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BOProcessResult> ConfirmOTPCode(OTPConfirmRequest request)
        {
            RequestOTPData lastData;
            BOProcessResult processResult = new BOProcessResult();

            BuildConfiguration(request.TCodeKey);

            //co 1 so rule se dc add vao trong request sau buoc nay
            request.AppConfig = otpConfig;

            bool result = false;
            if (!request.IsValid)
            {
                processResult.Content = null;
                LogError(request.GetAllError());
                processResult.Errors.AddRange(request.GetAllError());
                return processResult;
            }

            int dataRangge = OTPConfig.RequestDataRange;
            DateTime allowLastRequestDateTime = DateTime.Now.AddHours(dataRangge * -1);

            //2.lay data ra de kiem tra session va sequence
            BOProcessResult dataProcessResult = await DataHandler.GetLastOTPData(request.TCodeKey, request.RequesterID, allowLastRequestDateTime);

            if (dataProcessResult.Errors.Count != 0)
            {

                processResult.Content = null;
                LogError(dataProcessResult.Errors);
                processResult.Errors.AddRange(dataProcessResult.Errors);
                return processResult;
            }
            lastData = (RequestOTPData)dataProcessResult.Content;
            if (lastData == null)
            {
                processResult.Content = null;
                MSAError error = new MSAError();
                error.Description = "No OTPCode found";
                error.Property = "generic";
                error.RuleName = "ConfirmOTPCode";

                processResult.Errors.Add(error);
                LogError(processResult.Errors);
                return processResult;

            }
            else
            {
                if (lastData.OTPCode == request.OTPCode && lastData.ExpiredDateTime > DateTime.Now && request.SessionID == lastData.SessionID)
                {
                    result = true;
                }
                else
                {
                    processResult.Content = null;
                    MSAError error = new MSAError();
                    error.Description = "Wrong OTPCode or Session, or OTP Code is expired";
                    error.Property = "generic";
                    error.RuleName = "ConfirmOTPCode";

                    processResult.Errors.Add(error);
                    LogError(processResult.Errors);
                    return processResult;
                }
            }
            processResult.Content = result;
            return processResult;
        }

        /// <summary>
        /// xay dung lai OTPconfig can cu vao TCode key
        /// TCode Key la key dai dien cho 1 ung dung & 1 cong ty
        /// </summary>
        /// <param name="TCodeKey"></param>
        private void BuildConfiguration(string TCodeKey)
        {
            List<OTPConfigData> otpConfigDatas = (List<OTPConfigData>)DataHandler.GetOTPConfig(TCodeKey).Result.Content;

            if (otpConfigDatas == null || otpConfigDatas.Count == 0)
            {
                return;
            }

            //OTPConfiguration otpConfig = new OTPConfiguration();

            foreach (var item in otpConfigDatas)
            {
                switch (item.Number)
                {
                    case "ExpiredIn":
                        OTPConfig.ExpiredIn = Convert.ToInt32(item.KeyValue);
                        break;
                    case "MaxSessionLimit":
                        OTPConfig.MaxSessionLimit = Convert.ToInt32(item.KeyValue);
                        break;
                    case "MaxSequence":
                        OTPConfig.ExpiredIn = Convert.ToInt32(item.KeyValue);
                        break;
                    case "MaxSecondsBWRequest":
                        OTPConfig.ExpiredIn = Convert.ToInt32(item.KeyValue);
                        break;
                    case "RequestDataRange":
                        OTPConfig.RequestDataRange = Convert.ToInt32(item.KeyValue);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
