using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.DataHandler
{
    //[Table("[OTPConfig]")]
    public class OTPConfigData
    {
        public int ID { get; set; }
        public Guid TCodeKey { get; set; } //thoi gian cho phep gui request giua 2 session (thi du request tiep theo cach request truoc do >30 phut)
        public string Number { get; set; } //thoi gian cho phep gui request giua 2 session (thi du request tiep theo cach request truoc do >30 phut)
        public string KeyValue { get; set; } //so lan goi toi da trong 1 session
        public string Description { get; set; } //thoi gian expired 1 request trong 1 session
        public string CreatedBy { get; set; } //thoi gian toi da giua 2 request trong 1 session
        public string ModifiedBy { get; set; } //thoi gian toi da giua 2 request trong 1 session
        public DateTime CreatedOn { get; set; } //thoi gian toi da giua 2 request trong 1 session
        public DateTime ModifiedOn { get; set; } //thoi gian toi da giua 2 request trong 1 session
    }
}
