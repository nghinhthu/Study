using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public class CategoryMobile : Category
    {
        private string description;

        public CategoryMobile(string nameOfCategory, string description) : base(nameOfCategory)
        {
            this.description = description;
        }

        public string Description
        {
            set => description = value;
            get => description;
        }
    }
}
