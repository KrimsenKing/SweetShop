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
        //**Possible deletion
        //public List<Clubs> GetItemByID(Int32 ItemNumber)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Connection = conn;
        //    //cmd.CommandText = "Select * From Inventory Where ItemNumber = @ItemNumber";
        //    cmd.CommandText = "Select sku , brand, model, clubType, shaft,numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice,  clubSpec, shaftSpec, shaftFlex, dexterity, gst, pst From Item Where SKU = @sku";
        //    cmd.Parameters.AddWithValue("sku", ItemNumber);

        //    conn.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    List<Clubs> clubs = new List<Clubs>();

        //    while (reader.Read())
        //    {
        //        Clubs c = new Clubs
        //        (Convert.ToInt32(reader["sku"]),
        //        ConvertDBNullToString( reader["Brand"]).ToString(),
        //        reader["Model"].ToString(),
        //        reader["ClubType"].ToString(),
        //        reader["Shaft"].ToString(),
        //        reader["NumberOfClubs"].ToString(),
        //        Convert.ToDouble(reader["tradeInPrice"]),
        //        Convert.ToDouble(reader["premium"]),
        //        Convert.ToDouble(reader["wePay"]),
        //        Convert.ToInt32(reader["quantity"]),
        //        Convert.ToDouble(reader["extendedPrice"]),
        //        ConvertDBNullToDouble(reader["retailPrice"]),
        //        reader["ClubSpec"].ToString(),
        //        reader["ShaftSpec"].ToString(),
        //        reader["ShaftFlex"].ToString(),
        //        reader["Dexterity"].ToString(),
        //        Convert.ToBoolean(reader["GST"]),
        //        Convert.ToBoolean(reader["PST"])
        //        );


        //        clubs.Add(c);
        //    }
        //    conn.Close();
        //    return clubs;

        //}

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

        public List<Items> getItemByID(Int32 ItemNumber)
        {
            List<Items> items = new List<Items>();
            Items i = new Items();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "Select sku ,price From tbl_accessories Where SKU = @skuAcc";
            cmd.Parameters.AddWithValue("skuAcc", ItemNumber);

            SqlDataReader readerAcc = cmd.ExecuteReader();
            while (readerAcc.Read())
            {

                i = new Items(
                   Convert.ToInt32(readerAcc["sku"]),
                   //reader["Model"].ToString(),
                   //Convert.ToInt32(readerAcc["quantity"]),
                    Convert.ToDouble(readerAcc["price"])
                   );

            }
            if (!readerAcc.HasRows)
            {
                readerAcc.Close();
                cmd.CommandText = "Select sku ,price From tbl_clubs Where SKU = @skuClubs";
                cmd.Parameters.AddWithValue("skuClubs", ItemNumber);
                SqlDataReader readerClubs = cmd.ExecuteReader();
                while (readerClubs.Read())
                {
                    i = new Items(
                       Convert.ToInt32(readerClubs["sku"]),
                       //reader["Model"].ToString(),
                       //Convert.ToInt32(readerClubs["quantity"]),
                        Convert.ToDouble(readerClubs["price"])
                       );

                }
                if (!readerClubs.HasRows)
                {
                    readerClubs.Close();
                    cmd.CommandText = "Select sku ,price From tbl_clothing Where SKU = @skuClothing";
                    cmd.Parameters.AddWithValue("skuClothing", ItemNumber);
                    SqlDataReader readerClothing = cmd.ExecuteReader();
                    while (readerClothing.Read())
                    {
                        i = new Items(
                           Convert.ToInt32(readerClothing["sku"]),
                           //reader["Model"].ToString(),
                           //Convert.ToInt32(readerClothing["quantity"]),
                            Convert.ToDouble(readerClothing["price"])
                           );


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


    }
}