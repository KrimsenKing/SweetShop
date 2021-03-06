﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS.ClassLibrary
{
    public class CheckoutManager
    {
        public double dblTotal { get; set; }
        public double dblDiscounts { get; set; }
        public double dblTradeIn { get; set; }
        public double dblShipping { get; set; }
        public double dblSubTotal { get; set; }
        public bool blGst { get; set; }
        public bool blPst { get; set; }
        public double dblGst { get; set; }
        public double dblPst { get; set; }
        public double dblRemainingBalance { get; set; }
        public double dblAmountPaid { get; set; }
        public CheckoutManager() { }
        public CheckoutManager(double T, double D, double TI, double S, bool bG, bool bP, double dG, double dP,double AP, double RB)
        {
            dblTotal = T;
            dblDiscounts = D;
            dblTradeIn = TI;
            dblShipping = S;
            blGst = bG;
            blPst = bP;
            dblGst = dG;
            dblPst = dP;
            dblAmountPaid = AP;
            dblRemainingBalance = RB;
            dblSubTotal = T + S - (D + TI);
        }
    }
}