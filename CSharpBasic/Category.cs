using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public class Category
    {
        private string categoryName;

        public Category(string nameOfCategory) => categoryName = nameOfCategory;

        public string Name
        {
            set => categoryName = value;
            get => categoryName;
        }
    }
}
