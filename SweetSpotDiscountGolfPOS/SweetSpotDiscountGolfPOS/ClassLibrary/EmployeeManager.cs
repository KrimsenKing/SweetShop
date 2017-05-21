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
        //returns employeeID after adding employee to table created by Nathan
        public int addEmployee(Employee em)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into tbl_employee (firstName, lastName, jobID, locationID, email, primaryContactINT,"
                + " secondaryContactINT, primaryAddress, secondaryAddress, city, provStateID, countryID, postZip) Values"
                + " (@firstName, @lastName, @jobID, @locationID, @email, @primaryContactINT, @secondaryContactINT, @primaryAddress,"
                + " @secondaryAddress, @city, @province, @country, @postalCode)";
            cmd.Parameters.AddWithValue("firstName", em.firstName);
            cmd.Parameters.AddWithValue("lastName", em.lastName);
            cmd.Parameters.AddWithValue("jobID", em.jobID);
            cmd.Parameters.AddWithValue("locationID", em.locationID);
            cmd.Parameters.AddWithValue("email", em.emailAddress);
            cmd.Parameters.AddWithValue("primaryContactINT", em.primaryContactNumber);
            cmd.Parameters.AddWithValue("secondaryContactINT", em.secondaryContactNumber);
            cmd.Parameters.AddWithValue("primaryAddress", em.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", em.secondaryAddress);
            cmd.Parameters.AddWithValue("city", em.city);
            cmd.Parameters.AddWithValue("province", em.provState);
            cmd.Parameters.AddWithValue("country", em.country);
            cmd.Parameters.AddWithValue("postalCode", em.postZip);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();

            return returnEmployeeNumber(em);
        }
        //returns employeeID created by Nathan
        public int returnEmployeeNumber(Employee em)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select empID From tbl_employee Where firstName = @firstName and lastName = @lastName and jobID = @jobID and"
                + " locationID and @locationID and email = @email and primaryContactINT = @primaryContactINT and secondaryContactINT ="
                + " @secondaryContactINT and primaryAddress = @primaryAddress and secondaryAddress = @secondaryAddress and city = @city"
                + " and provStateID = @province and countryID = @country and postZip = @postalCode;";
            cmd.Parameters.AddWithValue("firstName", em.firstName);
            cmd.Parameters.AddWithValue("lastName", em.lastName);
            cmd.Parameters.AddWithValue("jobID", em.jobID);
            cmd.Parameters.AddWithValue("locationID", em.locationID);
            cmd.Parameters.AddWithValue("email", em.emailAddress);
            cmd.Parameters.AddWithValue("primaryContactINT", em.primaryContactNumber);
            cmd.Parameters.AddWithValue("secondaryContactINT", em.secondaryContactNumber);
            cmd.Parameters.AddWithValue("primaryAddress", em.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", em.secondaryAddress);
            cmd.Parameters.AddWithValue("city", em.city);
            cmd.Parameters.AddWithValue("province", em.provState);
            cmd.Parameters.AddWithValue("country", em.country);
            cmd.Parameters.AddWithValue("postalCode", em.postZip);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //New Customer number
            int empNum = 0;

            //Begin reading
            while (reader.Read())
            {
                empNum = Convert.ToInt32(reader["empID"]);
            }
            con.Close();
            return empNum;
        }
        //Update Employee Nathan and Tyler Created
        public void updateEmployee(Employee em)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Update tbl_employee Set firstName = @firstName and lastName = @lastName and jobID = @jobID and"
                + " locationID and @locationID and email = @email and primaryContactINT = @primaryContactINT and secondaryContactINT ="
                + " @secondaryContactINT and primaryAddress = @primaryAddress and secondaryAddress = @secondaryAddress and city = @city"
                + " and provStateID = @province and countryID = @country and postZip = @postalCode Where empID = @employeeID";
            cmd.Parameters.AddWithValue("employeeID", em.employeeID);
            cmd.Parameters.AddWithValue("firstName", em.firstName);
            cmd.Parameters.AddWithValue("lastName", em.lastName);
            cmd.Parameters.AddWithValue("jobID", em.jobID);
            cmd.Parameters.AddWithValue("locationID", em.locationID);
            cmd.Parameters.AddWithValue("email", em.emailAddress);
            cmd.Parameters.AddWithValue("primaryContactINT", em.primaryContactNumber);
            cmd.Parameters.AddWithValue("secondaryContactINT", em.secondaryContactNumber);
            cmd.Parameters.AddWithValue("primaryAddress", em.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", em.secondaryAddress);
            cmd.Parameters.AddWithValue("city", em.city);
            cmd.Parameters.AddWithValue("province", em.provState);
            cmd.Parameters.AddWithValue("country", em.country);
            cmd.Parameters.AddWithValue("postalCode", em.postZip);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();

            //Execute Update
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
