using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetSpot
{
    public class Brand
    {
        public int brandID;
        public string brandName;

        public Brand() { }

        public Brand(int id, string name)
        {
            brandID = id;
            brandName = name;
        }
    }
}