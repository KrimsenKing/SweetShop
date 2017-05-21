using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Accessories
    {
        public int sku { get; set; }
        public int brandID { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        public int quantity { get; set; }
        public int typeID { get; set; }

        public Accessories(){}
        public Accessories(int s, int b, string z, string clr, double p, double c, int q, int t)
        {
            sku = s;
            brandID = b;
            size = z;
            color = clr;
            price = p;
            cost = c;
            quantity = q;
            typeID = t;
        }
    }
}
