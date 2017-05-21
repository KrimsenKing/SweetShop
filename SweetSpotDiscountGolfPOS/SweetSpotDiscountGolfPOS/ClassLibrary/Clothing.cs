using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Clothing
    {
        public int sku { get; set; }
        public int brandID { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string gender { get; set; }
        public string style { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        public int quantity { get; set; }
        public int typeID { get; set; }

        public Clothing() { }
        public Clothing(int s, int b, string z, string clr, string g, string syl, double p, double c, int q, int t)
        {
            sku = s;
            brandID = b;
            size = z;
            color = clr;
            gender = g;
            style = syl;
            price = p;
            cost = c;
            quantity = q;
            typeID = t;
        }
    }
}
