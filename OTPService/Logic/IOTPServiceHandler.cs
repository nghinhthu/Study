using MSA.FW.Validation;
using OTPService.DataHandler;
using OTPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Logic
{
    public interface IOTPServiceHandler
    {
        OTPConfiguration OTPConfig { get; set; }
        IOTPDataHandler DataHandler { get; set; }
        Task<BOProcessResult> ConfirmOTPCode(OTPConfirmRequest request);
        Task<BOProcessResult> GetOTPCode(RequestOTP request);
    }
}
