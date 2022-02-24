using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Models
{
    public class ClassModel
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
