using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Items
    {
        public int sku { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int quantityInOrder { get; set; }
        public double price { get; set; }
        public double cost { get; set; }


        public Items() { }

        public Items(int s, string d, int q, double p, double c)
        {
            sku = s;
            description = d;
            quantity = q;
            price = p;
            cost = c;
        }

        public Items(int sk,  double prc)
        {
            sku = sk;
            quantityInOrder = 1;
            price = prc;
        }
    }
}
