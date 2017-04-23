using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    class Clothing
    {
        private int sku { get; set; }
        private int brandID { get; set; }
        private string size { get; set; }
        private string color { get; set; }
        private string gender { get; set; }
        private string style { get; set; }
        private float price { get; set; }
        private float cost { get; set; }
        private int quantity { get; set; }

        public Clothing() { }
        public Clothing(int s, int b, string z, string clr, string g, string syl, float p, float c, int q)
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
        }
    }
}
