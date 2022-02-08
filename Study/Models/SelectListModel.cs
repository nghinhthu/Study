using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Models
{
    public class SelectListModel
    {
        public SelectListModel(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
