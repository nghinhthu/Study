using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Logic
{
    /// <summary>
    /// session la 1 lan giao dich, trong 1 giao dich, user dc phep request OTP nh lan 
    /// 1/MaxSessionLimit: TG toi da cho phep 2 giao dich, thi du 4g, nghia la trong 4g chi dc 1 transaction
    /// 2/MaxSequence: so lan request OTP toi da trong 1 giao dich
    /// 3/ExpiredIn: thoi gian 1 request OTP se bi expired
    /// 4/MaxSecondsBWRequest: mac du da co rang buoc so lan request trong 1 giao dich, 
    /// nhung cau hinh nay qui dinh TG toi da dc phep gui request o lan request tieo theo TRONG 1 GIAO DICH (SESSION ID)    
    /// 5/RequestDataRange: do viec luu tru thong tin OTP la vo cung lon, can gioi han lai viec lay data trong 1 khoang TG
    /// Tham so nay se qui dinh gioi han TG cho viec lay otpdata de xet duyet
    /// </summary>
    public class OTPConfiguration
    {
        public int MaxSessionLimit { get; set; }
        public int MaxSequence { get; set; }
        public int ExpiredIn { get; set; }
        public int MaxSecondsBWRequest { get; set; }
        public int RequestDataRange { get; set; }

    }
}
