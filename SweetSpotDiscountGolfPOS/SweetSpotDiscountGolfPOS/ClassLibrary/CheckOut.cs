using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SweetSpotDiscountGolfPOS.ClassLibrary
{
    public class CheckOut
    {
        private string connectionString;
        public int methodopayment { get; set; }
        public double amountopayment { get; set; }
        public string methoddesc { get; set; }

        public CheckOut()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString;
        }
        public CheckOut(int mop, double amp)
        {
            methodopayment = mop;
            methoddesc = GetMethodOfPaymentByID(mop);
            amountopayment = amp;
        }

        public string GetMethodOfPaymentByID(int mopID)
        {
            //Declares space for connection string and new command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select methodDesc From tbl_methodOfPayment Where methodID = " + mopID;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string mopD = "";
            while (reader.Read())
            {
                mopD = reader["methodDesc"].ToString();
            }
            con.Close();
            return mopD;
        }
    }
}