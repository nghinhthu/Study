using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Logic
{
    public class OTPConfiguration
    {
        public string MaxSessionLimit { get; set; }
        public string MaxSequence { get; set; }
        public string ExpiredIn { get; set; }
        public string MaxSecondsBWRequest { get; set; }
        public string RequestDataRange { get; set; }

    }
}
