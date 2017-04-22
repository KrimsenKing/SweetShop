using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    class Accessories
    {
        private int sku { get; set; }
        private int brandID { get; set; }
        private string size { get; set; }
        private string color { get; set; }
        private float price { get; set; }
        private float cost { get; set; }
        private int quantity { get; set; }

        public Accessories(){}
        public Accessories(int s, int b, string z, string clr, float p, float c, int q)
        {
            sku = s;
            brandID = b;
            size = z;
            color = clr;
            price = p;
            cost = c;
            quantity = q;
        }
    }
}
