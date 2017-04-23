using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Clubs
    {
        
        public int Sku { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int QuantityInOrder { get; set; }
        public double ItemSubTotal { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ClubType { get; set; }
        public string Shaft { get; set; }
        public string NumberOfClubs { get; set; }
        public double TradeInPrice { get; set; }
        public double Premium { get; set; }
        public double WePay { get; set; }
        public int Quantity { get; set; }
        public double ExtendedPrice { get; set; }
        public double RetailPrice { get; set; }
        public string Comments { get; set; }
        public string ClubSpec { get; set; }
        public string ShaftSpec { get; set; }
        public string ShaftFlex { get; set; }
        public string Dexterity { get; set; }
        public string Destination { get; set; }
        public bool Received { get; set; }
        public bool Paid { get; set; }
        public bool Gst { get; set; }
        public bool Pst { get; set; }
        public double GstAmount { get; set; }
        public double PstAmount { get; set; }

        public Clubs() { }

        public Clubs(int SKU, DateTime ShipDate, string brand,
            string model, string clubType, string shaft, string numberOfClubs,
            double tradeInPrice, double premium, double wePay, int quantity,
            double extendedPrice, double retailPrice, string comments,
            string clubSpec, string shaftSpec, string shaftFlex, string dexterity,
            string destination, bool received, bool paid, bool gST, bool pST)
        {
            Sku = SKU;
            ShipmentDate = ShipDate;
            Brand = brand;
            Model = model;
            ClubType = clubType;
            Shaft = shaft;
            NumberOfClubs = numberOfClubs;
            TradeInPrice = tradeInPrice;
            Premium = premium;
            WePay = wePay;
            Quantity = quantity;
            ExtendedPrice = extendedPrice;
            RetailPrice = retailPrice;
            Comments = comments;
            ClubSpec = clubSpec;
            ShaftSpec = shaftSpec;
            ShaftFlex = shaftFlex;
            Dexterity = dexterity;
            Destination = destination;
            Received = received;
            Paid = paid;
            Gst = gST;
            Pst = pST;
            QuantityInOrder = 1;
            ItemSubTotal = RetailPrice * QuantityInOrder;

        }

        public Clubs(int sKU, string brand, string model, string clubType, string shaft, string numberOfClubs,
            double tradeInPrice, double premium, double wePay, int quantity, double extendedPrice, double retailPrice,
            string clubSpec, string shaftSpec, string shaftFlex, string dexterity)
        {
            Sku = sKU;
            Brand = brand;
            Model = model;
            ClubType = clubType;
            Shaft = shaft;
            NumberOfClubs = numberOfClubs;
            TradeInPrice = tradeInPrice;
            Premium = premium;
            WePay = wePay;
            Quantity = quantity;
            ExtendedPrice = extendedPrice;
            RetailPrice = retailPrice;
            ClubSpec = clubSpec;
            ShaftSpec = shaftSpec;
            ShaftFlex = shaftFlex;
            Dexterity = dexterity;
            QuantityInOrder = 1;
            ItemSubTotal = RetailPrice * QuantityInOrder;

        }

        public Clubs(int sKU,int quantityInOrder, string brand, string model, string clubType, string shaft, string numberOfClubs,
         double tradeInPrice, double premium, double wePay, int quantity, double extendedPrice, double retailPrice,
         string clubSpec, string shaftSpec, string shaftFlex, string dexterity,bool gST,bool pST)
        {
            Sku = sKU;
            Brand = brand;
            Model = model;
            ClubType = clubType;
            Shaft = shaft;
            NumberOfClubs = numberOfClubs;
            TradeInPrice = tradeInPrice;
            Premium = premium;
            WePay = wePay;
            Quantity = quantity;
            ExtendedPrice = extendedPrice;
            RetailPrice = retailPrice;
            ClubSpec = clubSpec;
            ShaftSpec = shaftSpec;
            ShaftFlex = shaftFlex;
            Dexterity = dexterity;
            Gst = gST;
            Pst = pST;
            ItemSubTotal = RetailPrice * quantityInOrder;

        }

        public Clubs(int SKU, string brand, string model, string clubType, string shaft, string numberOfClubs, double tradeInPrice,
            double premium, double wePay, int quantity, double extendedPrice, double retailPrice, string clubSpec,
            string shaftSpec, string shaftFlex, string dexterity, bool gST, bool pST)
        {
            Sku = SKU;
            Brand = brand;
            Model = model;
            ClubType = clubType;
            Shaft = shaft;
            NumberOfClubs = numberOfClubs;
            TradeInPrice = tradeInPrice;
            Premium = premium;
            WePay = wePay;
            Quantity = quantity;
            ExtendedPrice = extendedPrice;
            RetailPrice = retailPrice;
            ClubSpec = clubSpec;
            ShaftSpec = shaftSpec;
            ShaftFlex = shaftFlex;
            Dexterity = dexterity;
            Gst = gST;
            Pst = pST;
        }


    }
}
