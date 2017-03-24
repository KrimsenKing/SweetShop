using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication1
{
    public class InvoiceUtil
    {
        private string connectionString;

        public InvoiceUtil()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Item> getItemByID(long ItemNumber)
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = conn;
            //cmd.CommandText = "Select * From Inventory Where ItemNumber = @ItemNumber";
            cmd.CommandText = "Select ItemNumber, Brand, Model, Club_Type as [Club Type], Shaft_Spec as Shaft, Shaft_Flex as Flex, Dexterity, Number_Of_Clubs as [Number of Clubs], RetailPrice as Price From Inventory Where ItemNumber = @ItemNumber";
            cmd.Parameters.AddWithValue("ItemNumber", ItemNumber);

            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();

            while (reader.Read())
            {
                Item i = new Item
                (Convert.ToInt64(reader["ItemNumber"]),
                reader["Brand"].ToString(),
                reader["Model"].ToString(),
                reader["Club Type"].ToString(),
                reader["Shaft"].ToString(),
                reader["Flex"].ToString(),
                reader["Dexterity"].ToString(),
                reader["Number Of Clubs"].ToString(),
                (Convert.ToInt32(reader["Price"]))

                );

                /*
                 * Item i = new Item
                (Convert.ToInt32(reader["ItemNumber"]),
                reader["Brand"].ToString(),
                reader["Model"].ToString(),
                reader["Club_Type"].ToString(),
                reader["Shaft_Spec"].ToString(),
                reader["Shaft_Flex"].ToString(),
                reader["Dexterity"].ToString(),
                reader["Number_Of_Clubs"].ToString(),
                (Convert.ToInt32(reader["RetailPrice"]))
                
                );
                 * */

                items.Add(i);
            }
            conn.Close();
            return items;

        }
    }
}