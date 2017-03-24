using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
//using System.Data.OleDb.OleDbConnection;
using System.Data.OleDb;
using System.Web.Configuration;

namespace SweetSpot1
{
    public class CustomerDataUtilities
    {

        private string connectionString;
        //private string visualConnection;

        public CustomerDataUtilities()
        {
            //connectionString = ConfigurationManager.ConnectionStrings["SweetSpot1.Properties.Settings.SweetSpotConnectionString"].ConnectionString;
            //visualConnection = ConfigurationManager.ConnectionStrings["SweetSpot1.Properties.Settings.SweetSpotConnectionString"].ConnectionString;
            connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Customer> getCustomer(int PhoneNumber)
        {
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand();


            cmd.Connection = con;
            cmd.CommandText = "SELECT * From Customer WHERE PhoneNumber=@PhoneNumber";
            cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);//7523567

            con.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            //SqlDataReader read = cmd.ExecuteReader();
            List<Customer> customer = new List<Customer>();

            while (read.Read())
            {
                Customer c = new Customer( Convert.ToInt32(read["CustomerId"]),
                    read["FirstName"].ToString(), 
                    read["LastName"].ToString(), 
                    read["Email"].ToString(),
                    read["Address"].ToString(),
                    read["City"].ToString(),
                    read["State"].ToString(),
                    read["Country"].ToString(),
                    read["ZipCode"].ToString(),
                    read["PhoneNumber"].ToString(),
                    read["EbayUserName"].ToString()
                    );

                customer.Add(c);
            }
            con.Close();
            return customer;
        }


        public Customer getCustomerById(int id)
        {
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand();


            cmd.Connection = con;
            cmd.CommandText = "SELECT * From Customer WHERE CustomerId=@CustomerId";
            cmd.Parameters.AddWithValue("Customer", id);//7523567

            con.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            //SqlDataReader read = cmd.ExecuteReader();
          

           read.Read();
           
                Customer c = new Customer(Convert.ToInt32(read["CustomerId"]),
                    read["FirstName"].ToString(),
                    read["LastName"].ToString(),
                    read["Email"].ToString(),
                    read["Address"].ToString(),
                    read["City"].ToString(),
                    read["State"].ToString(),
                    read["Country"].ToString(),
                    read["ZipCode"].ToString(),
                    read["PhoneNumber"].ToString(),
                    read["EbayUserName"].ToString()
                    );

             

            con.Close();
            return c;
        }


        public List<Customer> getCustomer()
        {
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand();


            cmd.Connection = con;
            cmd.CommandText = "SELECT * From Customer";
            //cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);//7523567

            con.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            //SqlDataReader read = cmd.ExecuteReader();
            List<Customer> customer = new List<Customer>();

            while (read.Read())
            {
                Customer c = new Customer(read["FirstName"].ToString(),
                    read["LastName"].ToString(),
                    read["Email"].ToString(),
                    read["Address"].ToString(),
                    read["City"].ToString(),
                    read["State"].ToString(),
                    read["Country"].ToString(),
                    read["ZipCode"].ToString(),
                    read["PhoneNumber"].ToString(),
                    read["EbayUserName"].ToString()
                    );

                customer.Add(c);
            }
            con.Close();
            return customer;
        }

        public void addCustomer(Customer c)
        {
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand();


            
            cmd.CommandText = "INSERT INTO Customer (FirstName, LastName, Email, Address, City, State, Country, ZipCode, PhoneNumber,EbayUserName) VALUES (@FirstName, @LastName, @Email, @Address, @City, @State, @Country, @ZipCode, @PhoneNumber,@EbayUserName)";
            cmd.Parameters.AddWithValue("FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("LastName", c.LastName);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.Parameters.AddWithValue("Address", c.Address);
            cmd.Parameters.AddWithValue("City", c.City);
            cmd.Parameters.AddWithValue("State", c.State);
            cmd.Parameters.AddWithValue("Country", c.Country);
            cmd.Parameters.AddWithValue("ZipCode", c.ZipCode);
            cmd.Parameters.AddWithValue("PhoneNumber", c.PhoneNumber);//7523567
            cmd.Parameters.AddWithValue("EbayUserName", c.EbayUserName);
            
            cmd.Connection = con;
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            //OleDbDataReader read = cmd.ExecuteReader();
            ////SqlDataReader read = cmd.ExecuteReader();
            //List<Customer> customer = new List<Customer>();

            //while (read.Read())
            //{
            //    Customer c = new Customer(read["FirstName"].ToString(),
            //        read["LastName"].ToString(),
            //        read["Email"].ToString(),
            //        read["Address"].ToString(),
            //        read["City"].ToString(),
            //        read["State"].ToString(),
            //        read["Country"].ToString(),
            //        read["ZipCode"].ToString(),
            //        read["PhoneNumber"].ToString(),
            //        read["EbayUserName"].ToString()
            //        );

            //    customer.Add(c);
            //}
            //con.Close();
            //return customer;
        }
    }
}
