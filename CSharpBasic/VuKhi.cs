using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public class VuKhi
    {
        public string name = "Ten vu khi";
        public int doSatThuong = 0;

        public VuKhi()
        {
            this.doSatThuong = 1;
        }

        public VuKhi(string name, int mucDo)
        {
            this.name = name;
            this.doSatThuong = mucDo;
            SetDoSatThuong(mucDo);
        }

        public void SetDoSatThuong(int mucDo)
        {
            this.doSatThuong = mucDo;
        }

        public void TanCong()
        {
            Console.Write(name + ":\t");
            for (int i = 0; i < doSatThuong; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
        }
    }
}
