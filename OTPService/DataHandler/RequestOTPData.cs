using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.DataHandler
{
    [Table("[RequestOTP]")]

    public class RequestOTPData
    {
        public RequestOTPData()
        {
            OTPCode = "*****"; Sequence = -1;// data kg co
        }
        [ExplicitKey]
        public Guid ID { get; set; }
        public string RequesterID { get; set; }
        public string SessionID { get; set; } //Mã yc, là mã duy nhất sinh ra từ phía client, client se truyen len kieu GUID nhung luu tru la kieu string(cho tong quat)

        public string TCodeKey { get; set; } //==> dai dien cho App ID/ Client ID/Tcode     
        public DateTime RequestDateTime { get; set; }
        public DateTime GenerateDateTime { get; set; }
        public string OTPCode { get; set; }
        public int Sequence { get; set; }
        public int ExpiredIn { get; set; }
        public DateTime ExpiredDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
