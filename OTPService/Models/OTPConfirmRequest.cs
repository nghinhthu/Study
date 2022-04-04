using MSA.FW.Applications;
using MSA.FW.Validation;
using OTPService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Models
{
    public class OTPConfirmRequest : BO
    {
        OTPConfiguration appConfig;
        public OTPConfiguration AppConfig
        {
            get { return appConfig; }
            set
            {
                appConfig = value; AddAdditionalBusinessRules();
            }
        }
        /// <summary>
        /// hàm này chạy trong lệnh set của AppConfig
        /// </summary>
        private void AddAdditionalBusinessRules()
        {
            //thuc hien add cac business rule theo appConfig , nhớ remove cac rule cũ nếu có
        }
        public OTPConfirmRequest() : base()
        {

        }
        public OTPConfirmRequest(OTPConfirmModel model) : base()
        {
            this.SessionID = model.SessionID;
            this.RequesterID = model.RequesterID;
            this.TCodeKey = model.TCodeKey;
            this.OTPCode = model.OTPCode;
        }
        public string SessionID { get; set; } //Mã yc, là mã giao dich duy nhất sinh ra từ phía client, client se truyen len kieu GUID nhung luu tru la kieu string(cho tong quat)
        public string RequesterID { get; set; } //Dinh danh dai dien cho nguoi yc (no la thong tin suy ra tu SMS, Email, thong thuong la UserID)
        public string TCodeKey { get; set; } //==> dai dien cho App ID/ Client ID/Tcode      
        public string OTPCode { get; set; }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            this.ValidationRule.AddRule(GeneralValidation.NotNullEmptyString, "RequestDateTime");
            this.ValidationRule.AddRule(GeneralValidation.NotNullEmptyString, "TCodeKey");
            this.ValidationRule.AddRule(GeneralValidation.NotNullEmptyString, "SessionID");
            this.ValidationRule.AddRule(GeneralValidation.NotNullEmptyString, "RequesterID");

        }
    }
}
