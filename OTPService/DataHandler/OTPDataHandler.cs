using Dapper;
using MSA.DAPPER.DAL;
using MSA.FW.Applications;
using MSA.FW.BaseApp;
using MSA.FW.BaseApp.DataObjects;
using MSA.FW.Validation;
using OTPService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RequestOTP = OTPService.Models.RequestOTP;

namespace OTPService.DataHandler
{
    public class OTPDataHandler : IOTPDataHandler
    {
        string tableName = "[RequestOTP]";
        string connectionString;
        public OTPDataHandler(string _connectionString)
        {
            connectionString = _connectionString;

        }
        /// <summary>
        /// lay ra data ve request OTP cuối(lastRequestOTPData) cua user/requesterID tuong ung voi mã giao dich, 
        /// kg so sánh sessionID với request hiện tại
        /// muc dich cua data nay dung de xet cac business rule xac dinh tinh hop le cua request hien tai
        /// thi du nhu request hien tai la kh hop le vi vi pham rule so lan request trong 1 session
        /// </summary>
        /// <param name="tcodekey"></param>
        /// <param name="requesterID"></param>
        /// <param name="lastRequestDate"></param>
        /// <returns></returns>
        public async Task<BOProcessResult> GetLastOTPData(string tcodekey, string requesterID, DateTime lastRequestDate)
        {
            //string searchCondition = "TCodeKey=@TCodeKey AND RequesterID=@RequesterID AND RequestDateTime<=@LastRequestDate";
            DynamicParameters para = new DynamicParameters();
            para.Add("TCodeKey", tcodekey);
            para.Add("requesterID", requesterID);
            para.Add("allowLastRequestDateTime", lastRequestDate);
            IDbConnection connection = new SqlConnection(connectionString);
            string procedureName = "GetLastOTPData";
            BOProcessResult processResult = new BOProcessResult();
            try
            {
                RequestOTPData searchResults = await connection.QuerySingleOrDefaultAsync<RequestOTPData>(procedureName, para, commandType: CommandType.StoredProcedure);
                processResult.Content = searchResults;
                connection.Dispose();
            }
            catch (Exception ex)
            {
                processResult.Content = null;
                processResult.Errors.Add(new MSAError()
                {
                    Description = ex.Message,
                    Property = "generic",
                    ErrorCode = "ExecuteSPFailed",
                    RuleName = "General"
                }); ;
            }
            return processResult;
        }
        /// <summary>
        /// Get OTPConfig Data theo tcode key
        /// moi 1 loai giao dich cua 1 cong ty co config rieng
        /// </summary>
        /// <param name="TCodeKey"></param>
        /// <returns></returns>
        public async Task<BOProcessResult> GetOTPConfig(string TCodeKey)
        {
            MSADALHelper<OTPConfigData> dapperDataHelper = new MSADALHelper<OTPConfigData>(connectionString);
            string searchCondition = "TCodeKey=@TCodeKey AND IsDeleted=@IsDeleted";
            BOProcessResult boProcessResult = new BOProcessResult();
            try
            {
                Dictionary<string, object> parametters = new Dictionary<string, object>();
                parametters.Add("TCodeKey", TCodeKey);
                parametters.Add("IsDeleted", false);
                PageInfo pageInfo = new PageInfo(100);
                SearchResult searchResult = await dapperDataHelper.Read("[905_G_OTPConfig]", searchCondition, parametters, pageInfo, "ID ASC");
                if (searchResult.OK)
                {
                    List<OTPConfigData> data = (List<OTPConfigData>)searchResult.Data;
                    boProcessResult.Content = data;
                }
                else
                {
                    boProcessResult.Content = null;
                    boProcessResult.Errors.Add(new MSAError("DAL", "DAL exception"));
                }

            }
            catch (Exception ex)
            {
                boProcessResult.Content = null;
                boProcessResult.Errors.Add(new MSAError("DAL", ex.Message));
            }
            return boProcessResult;
        }




        /// <summary>
        /// Save a success request to DB (create new record), khi get 1 OTP request se luu lai lich su nay
        /// </summary>
        /// <param name="request"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task<BOProcessResult> SaveRequest(RequestOTP request, OTPResult result)
        {
            BOProcessResult processResult = new BOProcessResult();
            RequestOTPData data = new RequestOTPData()
            {
                ID = Guid.NewGuid(),
                OTPCode = result.OTPCode,
                RequestDateTime = request.RequestDateTime,
                GenerateDateTime = result.GenerateDateTime,
                RequesterID = request.RequesterID,
                Sequence = result.Sequence,
                SessionID = request.SessionID,
                TCodeKey = request.TCodeKey,

                ExpiredDateTime = result.ExpiredDateTime,
                ExpiredIn = result.ExpiredIn,
                CreatedOn = DateTime.Now,
                CreatedBy = request.RequesterID,
            };


            try
            {

                MSADALHelper<RequestOTPData> dapperDataHelper = new MSADALHelper<RequestOTPData>(connectionString);
                ObjectInfo<RequestOTPData> objInfo = new ObjectInfo<RequestOTPData>()
                {
                    CRUD = EDalOP.Create,
                    Data = data
                };
                ExecuteNonQueryResult insertResult = await dapperDataHelper.SaveData(objInfo, tableName);
                if (insertResult.OK)
                {
                    processResult.Content = insertResult.RowCount;
                }
                else
                {
                    processResult.Content = null;
                    processResult.Errors.Add(new MSAError()
                    {
                        Description = "DAL exception",
                        Property = "generic",
                        ErrorCode = "DALException",
                        RuleName = "General"
                    }); ;

                }



            }
            catch (Exception ex)
            {
                processResult.Content = null;
                processResult.Errors.Add(new MSAError()
                {
                    Description = ex.Message,
                    Property = "generic",
                    ErrorCode = "ExecuteSPFailed",
                    RuleName = "General"
                }); ;
            }


            return processResult;
        }
    }
}
