using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    class Items
    {
        private int sku { get; set; }
        private string description { get; set; }
        private int quantity { get; set; }
        private int price { get; set; }
        private int cost { get; set; }

        private string connectionString;

        public Items() { }

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
