using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    class EmployeeManager
    {
        String connectionString;
        public EmployeeManager()
        {

            connectionString = ConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString;
        }

        public Employee getEmployeeByID(int empID)
        {
            try
            {
                //Declares space for connection string and new command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * From tbl_employee Where empID = @empID;";
                cmd.Parameters.AddWithValue("empID", empID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //New Employee
                Employee employee = new Employee();

                //Begin reading
                while (reader.Read())
                {
                    Employee em = new Employee(Convert.ToInt32(reader["empID"]),
                        reader["firstName"].ToString(),
                        reader["lastName"].ToString(),
                        Convert.ToInt32(reader["jobID"]),
                        Convert.ToInt32(reader["locationID"]),
                        reader["email"].ToString(),
                        reader["primaryContactINT"].ToString(),
                        reader["secondaryContactINT"].ToString(),
                        reader["primaryAddress"].ToString(),
                        reader["secondaryAddress"].ToString(),
                        reader["city"].ToString(),
                        Convert.ToInt32(reader["provStateID"]),
                        Convert.ToInt32(reader["countryID"]),
                        reader["postZip"].ToString());

                    employee = em;
                }

                con.Close();
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
