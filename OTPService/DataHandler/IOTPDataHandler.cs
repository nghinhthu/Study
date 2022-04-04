using MSA.FW.Validation;
using OTPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.DataHandler
{
    public interface IOTPDataHandler
    {
        Task<BOProcessResult> GetOTPConfig(string TCodeKey);
        Task<BOProcessResult> GetLastOTPData(string TCodeKey, string requesterID, DateTime lastRequestDate);
        Task<BOProcessResult> SaveRequest(RequestOTP request, OTPResult result);
    }
}
