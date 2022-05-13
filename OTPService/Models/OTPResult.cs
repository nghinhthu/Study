using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Models
{
    public class OTPResult
    {
        public OTPResult()
        {
            OTPCode = "***"; Sequence = -1;
        }
        public string ID { get; set; } //tuong ung voi GuiD ID cua 1 record sinh ra tu rq, 
                                       //lan gui thu 2 se dung ma nay de kiem tra
        public string SessionID { get; set; } //tuong ung voi GuiD ID cua 1 record sinh ra tu rq, 
        public DateTime GenerateDateTime { get; set; }
        public int ExpiredIn { get; set; }
        public DateTime ExpiredDateTime { get; set; }
        public string OTPCode { get; set; } //ma OTP sinh ra
        public int Sequence { get; set; } //lan sinh ra
    }
}
