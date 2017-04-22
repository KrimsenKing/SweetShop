using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Clubs
    {
        
        public int sku { get; set; }
        public DateTime shipmentDate { get; set; }
        public int quantityInOrder { get; set; }
        public double itemSubTotal { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string clubType { get; set; }
        public string shaft { get; set; }
        public string numberOfClubs { get; set; }
        public double tradeInPrice { get; set; }
        public double premium { get; set; }
        public double wePay { get; set; }
        public int quantity { get; set; }
        public double extendedPrice { get; set; }
        public double retailPrice { get; set; }
        public string comments { get; set; }
        public string clubSpec { get; set; }
        public string shaftSpec { get; set; }
        public string shaftFlex { get; set; }
        public string dexterity { get; set; }
        public string destination { get; set; }
        public bool received { get; set; }
        public bool paid { get; set; }
        public bool gst { get; set; }
        public bool pst { get; set; }
        public double gstAmount { get; set; }
        public double pstAmount { get; set; }

        public Clubs() { }

        public Clubs(int SKU, DateTime ShipmentDate, string Brand,
            string Model, string ClubType, string Shaft, string NumberOfClubs,
            double TradeInPrice, double Premium, double WePay, int Quantity,
            double ExtendedPrice, double RetailPrice, string Comments,
            string ClubSpec, string ShaftSpec, string ShaftFlex, string Dexterity,
            string Destination, bool Received, bool Paid, bool GST, bool PST)
        {
            sku = SKU;
            shipmentDate = ShipmentDate;
            brand = Brand;
            model = Model;
            clubType = ClubType;
            shaft = Shaft;
            numberOfClubs = NumberOfClubs;
            tradeInPrice = TradeInPrice;
            premium = Premium;
            wePay = WePay;
            quantity = Quantity;
            extendedPrice = ExtendedPrice;
            retailPrice = RetailPrice;
            comments = Comments;
            clubSpec = ClubSpec;
            shaftSpec = ShaftSpec;
            shaftFlex = ShaftFlex;
            dexterity = Dexterity;
            destination = Destination;
            received = Received;
            paid = Paid;
            gst = GST;
            pst = PST;
            quantityInOrder = 1;
            itemSubTotal = retailPrice * quantityInOrder;

        }

        public Clubs(int SKU, string Brand, string Model, string ClubType, string Shaft, string NumberOfClubs,
            double TradeInPrice, double Premium, double WePay, int Quantity, double ExtendedPrice, double RetailPrice,
            string ClubSpec, string ShaftSpec, string ShaftFlex, string Dexterity)
        {
            sku = SKU;
            brand = Brand;
            model = Model;
            clubType = ClubType;
            shaft = Shaft;
            numberOfClubs = NumberOfClubs;
            tradeInPrice = TradeInPrice;
            premium = Premium;
            wePay = WePay;
            quantity = Quantity;
            extendedPrice = ExtendedPrice;
            retailPrice = RetailPrice;
            clubSpec = ClubSpec;
            shaftSpec = ShaftSpec;
            shaftFlex = ShaftFlex;
            dexterity = Dexterity;
            quantityInOrder = 1;
            itemSubTotal = retailPrice * quantityInOrder;

        }

        public Clubs(int SKU,int quantityInOrder, string Brand, string Model, string ClubType, string Shaft, string NumberOfClubs,
         double TradeInPrice, double Premium, double WePay, int Quantity, double ExtendedPrice, double RetailPrice,
         string ClubSpec, string ShaftSpec, string ShaftFlex, string Dexterity,bool GST,bool PST)
        {
            sku = SKU;
            brand = Brand;
            model = Model;
            clubType = ClubType;
            shaft = Shaft;
            numberOfClubs = NumberOfClubs;
            tradeInPrice = TradeInPrice;
            premium = Premium;
            wePay = WePay;
            quantity = Quantity;
            extendedPrice = ExtendedPrice;
            retailPrice = RetailPrice;
            clubSpec = ClubSpec;
            shaftSpec = ShaftSpec;
            shaftFlex = ShaftFlex;
            dexterity = Dexterity;
            gst = GST;
            pst = PST;
            itemSubTotal = retailPrice * quantityInOrder;

        }


    }
}
