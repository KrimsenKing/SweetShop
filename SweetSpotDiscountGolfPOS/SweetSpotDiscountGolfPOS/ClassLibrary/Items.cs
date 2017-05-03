using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Items
    {
        public int sku { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double cost { get; set; }

        private string connectionString;

        public Items() { }

        public Items(int s, string d, int q, double p, double c)
        {
            sku = s;
            description = d;
            quantity = q;
            price = p;
            cost = c;




        }

        public Items(int sku, int typeID)
        {
            string description;
            string qry;

            connectionString = "SweetSpotSBConnectionString";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select typeDescription from tbl_itemType Where typeID = @typeID";
            cmd.Parameters.AddWithValue("typeID", typeID);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();

            string table = "tbl_";

            qry = "Select * from " + table + " Where sku = " + sku;
            switch (typeID) { 
                case 1: //clubs
                    
                    break;
                case 2: //accessories
                    
                    break;
                case 3: //clothing
                    
                    break;
            }
        }
    }
}
