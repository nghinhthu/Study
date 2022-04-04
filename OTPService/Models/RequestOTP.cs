using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Models
{
    public class RequestOTP
    {
        public string SessionID { get; set; } //Mã yc, là mã giao dich duy nhất sinh ra từ phía client, client se truyen len kieu GUID nhung luu tru la kieu string(cho tong quat)
        public string RequesterID { get; set; } //Dinh danh dai dien cho nguoi yc (no la thong tin suy ra tu SMS, Email, thong thuong la UserID)
        public string TCodeKey { get; set; } //==> dai dien cho App ID/ Client ID/Tcode      
        public DateTime RequestDateTime { get; set; }
        public RequestOTP(OTPRequestModel model)
        {
            this.RequestDateTime = model.RequestDateTime;
            this.RequesterID = model.RequesterID;
            this.SessionID = model.SessionID;
            this.TCodeKey = model.TCodeKey;
            //OTPConfig = _otpConfig;
        }
    }
}
