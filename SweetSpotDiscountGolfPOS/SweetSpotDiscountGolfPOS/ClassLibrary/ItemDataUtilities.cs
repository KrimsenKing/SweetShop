using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SweetShop;

namespace SweetSpotProShop
{
    public class ItemDataUtilities
    {
        private String connectionString;

        public ItemDataUtilities()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["SweetSpotSBConnectionString"].ConnectionString;
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
                ConvertDBNullToString( reader["Brand"]).ToString(),
                reader["Model"].ToString(),
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


    }
}