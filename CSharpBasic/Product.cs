using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string nameProduct, decimal priceProduct)
        {
            this.name = nameProduct;
            this.price = priceProduct;
        }

        public Product()
        {
            this.name = "Khong ten";
            this.price = 0;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public decimal Price
        {
            set { price = value; }
            get { return price; }
        }
    }
}
