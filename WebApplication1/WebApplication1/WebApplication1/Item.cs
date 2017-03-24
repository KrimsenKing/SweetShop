using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Item
    {
        public long ItemNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Club_Type { get; set; }
        public string Shaft_Spec { get; set; }
        public string Shaft_Flex { get; set; }
        public string Dexterity { get; set; }
        public string Number_Of_Clubs { get; set; }
        public int RetailPrice { get; set; }

        public Item() { }

        public Item(long itemNumber, string brand, string model, string clubType,
            string shaftSpec, string shaftFlex, string dexterity, string numberOfClubs,
            int retailPrice)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Model = model;
            Club_Type = clubType;
            Shaft_Spec = shaftSpec;
            Shaft_Flex = shaftFlex;
            Dexterity = dexterity;
            Number_Of_Clubs = numberOfClubs;
            RetailPrice = retailPrice;
        }
     }
    
}