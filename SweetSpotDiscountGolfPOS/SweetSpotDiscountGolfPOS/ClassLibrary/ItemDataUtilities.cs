using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using SweetShop;

namespace SweetSpotProShop
{
    public class ItemDataUtilities
    {
        private String connectionString;

        public ItemDataUtilities()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString;
        }
        //Return Model string created by Nathan and Tyler
        public string modelType(int modelID)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select modelName from tbl_model where modelID = " + modelID;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string model = null;

            while (reader.Read())
            {
                string m = reader["modelName"].ToString();
                model = m;
            }
            conn.Close();
            return model;
        }
        //Return Brand string created by Nathan and Tyler
        public string brandType(int brandID)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select brandName from tbl_brand where brandID = " + brandID;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string brand = null;

            while (reader.Read())
            {
                string b = reader["brandName"].ToString();
                brand = b;
            }
            conn.Close();
            return brand;
        }
        //Return Model Int created by Nathan and Tyler
        public int modelName(string modelN)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select modelID from tbl_model where modelName = '" + modelN + "'";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int model = 0;
            while (reader.Read())
            {
                int m = Convert.ToInt32(reader["modelID"]);
                model = m;
            }
            conn.Close();
            return model;
        }
        //Return Brand Int created by Nathan and Tyler
        public int brandName(string brandN)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select brandID from tbl_brand where brandName = '" + brandN + "'";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int brand = 0;

            while (reader.Read())
            {
                int b = Convert.ToInt32(reader["brandID"]);
                brand = b;
            }
            conn.Close();
            return brand;
        }
        //Return Model string created by Nathan and Tyler
        public string typeName(int typeNum)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select typeDescription from tbl_itemType where typeID = " + typeNum;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string type = null;

            while (reader.Read())
            {
                string t = reader["typeDescription"].ToString();
                type = t;
            }
            conn.Close();
            return type;
        }
        //Adding items to the Cart class. Totally not stolen by Tickles
        public Cart addingToCart(Object o)
        {
            Cart ca = new Cart();
            if (o is Clubs)
            {
                Clubs c = o as Clubs;
                ca.sku = c.sku;
                ca.description = brandType(c.brandID) + " " + modelType(c.modelID) + " " + c.clubType + " " + c.shaft + " " + c.numberOfClubs + " " + c.dexterity;
                ca.price = c.price;
                ca.cost = c.cost;
            }
            else if (o is Accessories)
            {
                Accessories a = o as Accessories;
                ca.sku = a.sku;
                ca.description = brandType(a.brandID) + " " + a.size + " " + a.colour;
                ca.price = a.price;
                ca.cost = a.cost;
            }
            else if (o is Clothing)
            {
                Clothing cl = o as Clothing;
                ca.sku = cl.sku;
                ca.description = brandType(cl.brandID) + " " + cl.size + " " + cl.colour + " " + cl.gender + " " + cl.style;
                ca.price = cl.price;
                ca.cost = cl.cost;
            }
            ca.quantity = 1;
            return ca;
        }

        public List<Clubs> GetItemByID(Int32 ItemNumber)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            //cmd.CommandText = "Select * From Inventory Where ItemNumber = @ItemNumber";
            cmd.CommandText = "Select sku , brand, model, clubType, shaft,numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice,  clubSpec, shaftSpec, shaftFlex, dexterity, gst, pst From Item Where SKU = @sku";
            cmd.Parameters.AddWithValue("sku", ItemNumber);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clubs> clubs = new List<Clubs>();

            while (reader.Read())
            {
                Clubs c = new Clubs
                (Convert.ToInt32(reader["sku"]),
                Convert.ToInt32( reader["Brand"]),
                Convert.ToInt32(reader["Model"]),
                reader["ClubType"].ToString(),
                reader["Shaft"].ToString(),
                reader["NumberOfClubs"].ToString(),
                Convert.ToDouble(reader["tradeInPrice"]),
                Convert.ToDouble(reader["premium"]),
                Convert.ToDouble(reader["wePay"]),
                Convert.ToInt32(reader["quantity"]),
                Convert.ToDouble(reader["extendedPrice"]),
                ConvertDBNullToDouble(reader["retailPrice"]),
                reader["ClubSpec"].ToString(),
                reader["ShaftSpec"].ToString(),
                reader["ShaftFlex"].ToString(),
                reader["Dexterity"].ToString(),
                Convert.ToBoolean(reader["GST"]),
                Convert.ToBoolean(reader["PST"])
                );


                clubs.Add(c);
            }
            conn.Close();
            return clubs;

        }

        public string ConvertDBNullToString(Object o)
        {
            if (o is DBNull)
                o = "";

            return o.ToString();

        }
        public double ConvertDBNullToDouble(Object o)
        {
            double dbl = 0.0;
            if (o is DBNull)
                dbl = 0.0;
            else
                dbl = Convert.ToDouble(o);

            return dbl;

        }

        public double GetTaxRates(int ProId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select GST from StateProvLT where stateProvID = @ProId";
            cmd.Parameters.AddWithValue("@ProId", ProId);
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();

            read.Read();

            double t = Convert.ToDouble(read["gst"]);


            conn.Close();
            return t;
        }

        public double GetPSTTax(int ProId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select PST from StateProvLT where stateProvID = @ProId";
            cmd.Parameters.AddWithValue("@ProId", ProId);
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();

            read.Read();
            double t = Convert.ToDouble(read["pst"]);

            conn.Close();
            return t;
        }
        //populating gridView on Inventory Search button in Sales Cart
        public List<Items> getItemByID(Int32 ItemNumber)
        {
            List<Items> items = new List<Items>();
            Items i = new Items();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "Select sku, quantity, brandID, size, colour, price, cost From tbl_accessories Where SKU = @skuAcc";
            cmd.Parameters.AddWithValue("skuAcc", ItemNumber);

            SqlDataReader readerAcc = cmd.ExecuteReader();
            while (readerAcc.Read())
            {

                i = new Items(Convert.ToInt32(readerAcc["sku"]), brandType(Convert.ToInt32(readerAcc["brandID"]))
                    + " " + readerAcc["size"].ToString() + " " + readerAcc["colour"].ToString(),
                    Convert.ToInt32(readerAcc["quantity"]), Convert.ToDouble(readerAcc["price"]),
                    Convert.ToDouble(readerAcc["cost"]));

            }
            if (!readerAcc.HasRows)
            {
                readerAcc.Close();
                cmd.CommandText = "Select sku, brandID, modelID, clubType, shaft, numberOfClubs, dexterity, quantity, price, cost From tbl_clubs Where SKU = @skuClubs";
                cmd.Parameters.AddWithValue("skuClubs", ItemNumber);
                SqlDataReader readerClubs = cmd.ExecuteReader();
                while (readerClubs.Read())
                {
                    i = new Items(Convert.ToInt32(readerClubs["sku"]), brandType(Convert.ToInt32(readerClubs["brandID"]))
                        + " " + modelType(Convert.ToInt32(readerClubs["modelID"])) + " " + readerClubs["clubType"].ToString()
                        + " " + readerClubs["shaft"].ToString() + " " + readerClubs["numberOfClubs"].ToString() + " "
                        + readerClubs["dexterity"].ToString(), Convert.ToInt32(readerClubs["quantity"]),
                        Convert.ToDouble(readerClubs["price"]), Convert.ToDouble(readerClubs["cost"]));

                }
                if (!readerClubs.HasRows)
                {
                    readerClubs.Close();
                    cmd.CommandText = "Select sku, brandID, size, colour, gender, style, quantity, price, cost From tbl_clothing Where SKU = @skuClothing";
                    cmd.Parameters.AddWithValue("skuClothing", ItemNumber);
                    SqlDataReader readerClothing = cmd.ExecuteReader();
                    while (readerClothing.Read())
                    {
                        i = new Items(Convert.ToInt32(readerClothing["sku"]), brandType(Convert.ToInt32(readerClothing["brandID"]))
                            + " " + readerClothing["size"].ToString() + " " + readerClothing["colour"].ToString()
                            + " " + readerClothing["gender"].ToString() + " " + readerClothing["style"].ToString(),
                            Convert.ToInt32(readerClothing["quantity"]), Convert.ToDouble(readerClothing["price"]),
                            Convert.ToDouble(readerClothing["cost"]));
                    }
                }
            }
            if (i.sku > 0)
            {
                items.Add(i);
            }
            conn.Close();

            return items;

        }

        public List<Items> getquantity(Int32 sku)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            Items i = new Items();
            cmd.Connection = conn;
            cmd.CommandText = "Select quantity from tbl_clubs where SKU = @sku";
            cmd.Parameters.AddWithValue("sku", sku);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Items> clubs = new List<Items>();



            while (reader.Read())
            {
                i = new Items(
                    Convert.ToInt32(reader["quantity"]));
                //int m = Convert.ToInt32(reader["modelID"]);
                //qty = m;
            }
            if (!reader.HasRows)
            {
                reader.Close();
                cmd.CommandText = "Select quantity from tbl_accessories where SKU = @skuacces";
                cmd.Parameters.AddWithValue("skuacces", sku);
                // conn.Open();
                SqlDataReader readerAccesories = cmd.ExecuteReader();

                while (readerAccesories.Read())
                {
                    i = new Items(Convert.ToInt32(readerAccesories["quantity"]));
                }

                if (!readerAccesories.HasRows)
                {
                    readerAccesories.Close();
                    cmd.CommandText = "Select quantity from tbl_clothing where SKU = @skucloth";
                    cmd.Parameters.AddWithValue("skucloth", sku);
                    //conn.Open();
                    SqlDataReader readerclothing = cmd.ExecuteReader();

                    while (readerclothing.Read())
                    {
                        i = new Items(Convert.ToInt32(readerclothing["quantity"]));
                    }
                }
            }
            clubs.Add(i);

            conn.Close();
            // return clubs;
            return clubs;


        }


        //Grabbing trade-in sku
        public int tradeInSku(int location)
        {
            int sku = 0;
            int[] range = new int[2];
            range = tradeInSkuRange(location);
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select max(sku) as sku from tbl_tempTradeInCartSkus where locationID = " + location.ToString();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Clubs club = new Clubs();
            int maxSku = 0;
            while (reader.Read())
            {
                maxSku = (reader["sku"] as int?) ?? range[0]; //Setting it to 0
            }
            conn.Close();



            //If the maxSku returns as null, sets the sku as the min range
            if (maxSku.Equals(null))
            {
                sku = range[0];
            }
            //If the maxSku is less than the upper range, sku is the max sku + 1
            else if (maxSku < range[1])
            {
                sku = maxSku + 1;
            }
            //If the maxSku equals the upper range, sku equals the min range
            else if (maxSku == range[1])
            {
                sku = range[0];
            }


            return sku;
        }
        public int[] tradeInSkuRange(int location)
        {
            int[] range = new int[2];
            int upper = 0;
            int lower = 0;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select skuStartAt, skuStopAt from tbl_tradeInSkusForCart where locationID = " + location.ToString();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                upper = Convert.ToInt32(reader["skuStopAt"].ToString());
                lower = Convert.ToInt32(reader["skuStartAt"].ToString());
            }
            range[0] = lower;
            range[1] = upper;


            conn.Close();
            return range;
        }
        //Adding tradein item 
        public void addTradeInItem(Clubs tradeInItem)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            int used = 0;
            if (tradeInItem.used == true)
            {
                used = 1;
            }
            else
            {
                used = 0;
            }


            cmd.Connection = conn;
            cmd.CommandText = "insert into tbl_tempTradeInCartSkus values(" + tradeInItem.sku + ", " + tradeInItem.brandID + ", " +
                tradeInItem.modelID + ", '" + tradeInItem.clubType + "', '" + tradeInItem.shaft + "', '" + tradeInItem.numberOfClubs + "', " +
                tradeInItem.premium + ", " + tradeInItem.cost + ", " + tradeInItem.price + ", " + tradeInItem.quantity + ", '" +
                tradeInItem.clubSpec + "', '" + tradeInItem.shaftSpec + "', '" + tradeInItem.shaftFlex + "', '" +
                tradeInItem.dexterity + "', " + tradeInItem.typeID + ", " + tradeInItem.itemlocation + ", " +
                used + ", '" + tradeInItem.comments + "');";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
        }


    }
}