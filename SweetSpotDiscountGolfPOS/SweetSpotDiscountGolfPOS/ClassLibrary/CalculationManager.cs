using SweetShop;
using SweetSpotProShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetSpotDiscountGolfPOS.ClassLibrary
{
    public class CalculationManager
    {
        ItemDataUtilities idu = new ItemDataUtilities();
        public double returnDiscount(List<Cart> itemsSold)
        {
            double singleDiscoount = 0;
            double totalDiscount = 0;
            foreach (var cart in itemsSold)
            {
                if (cart.percentage)
                {
                    singleDiscoount = cart.quantity * (cart.price * (cart.discount / 100));
                }
                else
                {
                    singleDiscoount = cart.quantity * cart.discount;
                }
                totalDiscount += singleDiscoount;
            }
            return Math.Round(totalDiscount, 2);
        }
        public double returnTradeInAmount(List<Cart> itemsSold)
        {
            double singleTradeInAmount = 0;
            double totalTradeinAmount = 0;
            
            int[] range = idu.tradeInSkuRange(0);
            foreach (var cart in itemsSold)
            {
                if (cart.sku <= range[1] && cart.sku >= range[0])
                {
                    singleTradeInAmount = cart.quantity * cart.price;
                    totalTradeinAmount += singleTradeInAmount;
                }
            }
            return totalTradeinAmount;
        }
        public double returnSubtotalAmount(List<Cart> itemsSold)
        {
            double totalSubtotalAmount = 0;
            double totalDiscountAmount = returnDiscount(itemsSold);
            double totalTradeInAmount = returnTradeInAmount(itemsSold);
            double totalTotalAmount = returnTotalAmount(itemsSold);
            totalSubtotalAmount = totalSubtotalAmount + totalTotalAmount;
            totalSubtotalAmount = totalSubtotalAmount - totalDiscountAmount;
            totalSubtotalAmount = totalSubtotalAmount - (totalTradeInAmount * (-1));
            return totalSubtotalAmount;
        }
        public double returnTotalAmount(List<Cart> itemsSold)
        {
            int[] range = idu.tradeInSkuRange(0);
            double singleTotalAmount = 0;
            double totalTotalAmount = 0;
            foreach (var cart in itemsSold)
            {
                if (cart.sku >= range[1] || cart.sku <= range[0])
                {
                    singleTotalAmount = cart.quantity * cart.price;
                    totalTotalAmount += singleTotalAmount;
                }
            }
            return totalTotalAmount;
        }

        public double returnGSTAmount(double rate, List<Cart> cart)
        {
            double GSTAmount = 0;
            GSTAmount = Math.Round((rate * returnSubtotalAmount(cart)), 2);
            return GSTAmount;
        }
        public double returnPSTAmount(double rate, List<Cart> cart)
        {
            double PSTAmount = 0;
            PSTAmount = Math.Round((rate * returnSubtotalAmount(cart)), 2);
            return PSTAmount;
        }



        //Include shipping in the Subtotal


        //GST
        //PST -> If the order is being shipped, no PST
        //Remaining balance due
        //Balance due





    }
}