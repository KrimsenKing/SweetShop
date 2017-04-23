using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Tax
    {
        public double gst { get; set; }
        public double pst { get; set; }
        public int regionID { get; set; }

        public Tax() { }

        public Tax(double GST, double PST, int RegionID)
        {
            gst = GST;
            pst = PST;
            regionID = RegionID;
        }

        public Tax(double GST, double PST)
        {
            gst = GST;
            pst = PST;
        }

    }
}
