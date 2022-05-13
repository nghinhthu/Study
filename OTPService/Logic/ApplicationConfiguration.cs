using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Logic
{
    public class ApplicationConfiguration
    {
        public string ConnectionString { get; set; }
        public OTPConfiguration DefaultConfig { get; set; }
    }
}
