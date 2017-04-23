using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;


namespace SweetShop
{
    public class SweetShopManager
    {
        private string connectionString;

        public SweetShopManager()
        {

            connectionString = "SweetSpotSBConnectionString";
        }

        /*******Customer Utilities************************************************************************************/

        //Retrieves Customer by Phone Number
        public List<Customer> GetCustomerByPhoneNumber(String phoneNumber)
        {
            //Declares space for connection string and new command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Customer WHERE phoneNumber = @PhoneNumber";
            cmd.Parameters.AddWithValue("PhoneNumber", phoneNumber);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();

            //New List for Customer

            List<Customer> customer = new List<Customer>();

            //Begin reading
            while (read.Read())
            {
                Customer c = new Customer(Convert.ToInt32(read["CustomerId"]),
                    read["FirstName"].ToString(),
                    read["LastName"].ToString(),
                    read["primaryAddress"].ToString(),
                    read["secondaryAddress"].ToString(),
                    read["City"].ToString(),
                    read["PostalCode"].ToString(),
                    Convert.ToInt32(read["Province"]),
                    Convert.ToInt32(read["Country"]),
                    read["primaryPhoneNumber"].ToString(),
                    read["secondaryPhoneNumber"].ToString(),
                    read["Email"].ToString());

                customer.Add(c);

            }

            con.Close();
            return customer;
        }

        //Retrieve Customer by Customer ID
        public List<Customer> getCustomerByID(int CustomerID)
        {
            //Begin new command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * From Customer Where customerId = @CustomerID";
            cmd.Parameters.AddWithValue("CustomerID", CustomerID);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            //New List for Customer
            List<Customer> customer = new List<Customer>();
            //Begin Reading
            while (read.Read())
            {
                Customer c = new Customer((Convert.ToInt32(read["CustomerID"])),
                    read["FirstName"].ToString(),
                    read["LastName"].ToString(),
                    read["primaryAddress"].ToString(),
                    read["secondaryAddress"].ToString(),
                    read["City"].ToString(),
                    read["PostalCode"].ToString(),
                    Convert.ToInt32(read["Province"]),
                    Convert.ToInt32(read["Country"]),
                    read["primaryPhoneNumber"].ToString(),
                    read["secondaryPhoneNumber"].ToString(),
                    read["Email"].ToString());

                customer.Add(c);
            }
            con.Close();
            return customer;
        }

        //Add Customer
        public void addCustomer(Customer c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into Customer (FirstName, LastName, primaryAddress,"
                + " secondaryAddress, City, PostalCode, Province, Country, primaryPhoneNumber,"
                + " secondaryPhoneNumber, Email) Values (@FirstName,@LastName,@primaryAddress,@secondaryAddress,@City,@PostalCode,@Province,@Country,@primaryPhoneNumber,@secondaryPhoneNumber,@Email)";
            cmd.Parameters.AddWithValue("FirstName", c.firstName);
            cmd.Parameters.AddWithValue("LastName", c.lastName);
            cmd.Parameters.AddWithValue("primaryAddress", c.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", c.secondaryAddress);
            cmd.Parameters.AddWithValue("City", c.city);
            cmd.Parameters.AddWithValue("PostalCode", c.postalCode);
            cmd.Parameters.AddWithValue("Province", c.province);
            cmd.Parameters.AddWithValue("Country", c.country);
            cmd.Parameters.AddWithValue("primaryPhoneNumber", c.primaryPhoneNumber);
            cmd.Parameters.AddWithValue("secondaryPhoneNumber", c.secondaryPhoneNumber);
            cmd.Parameters.AddWithValue("Email", c.email);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Update Customer
        public void updateCustomer(Customer c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Update Customer Set FirstName = @FirstName, LastName = @LastName, primaryAddress = @primaryAddress, secondaryAddress = @secondaryAddress, City = @City, PostalCode = @PostalCode, Province = @Province, Country = @Country, primaryPhoneNumber = @primaryPhoneNumber, secondaryPhoneNumber = @secondaryPhoneNumber, Email = @Email Where customerId = @CustomerID";
            //Should these not be the text boxes???
            cmd.Parameters.AddWithValue("FirstName", c.firstName);
            cmd.Parameters.AddWithValue("LastName", c.lastName);
            cmd.Parameters.AddWithValue("primaryAddress", c.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", c.secondaryAddress);
            cmd.Parameters.AddWithValue("City", c.city);
            cmd.Parameters.AddWithValue("PostalCode", c.postalCode);
            cmd.Parameters.AddWithValue("Province", c.province);
            cmd.Parameters.AddWithValue("Country", c.country);
            cmd.Parameters.AddWithValue("primaryPhoneNumber", c.primaryPhoneNumber);
            cmd.Parameters.AddWithValue("secondaryPhoneNumber", c.secondaryPhoneNumber);
            cmd.Parameters.AddWithValue("Email", c.email);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();

            //Execute Update
            cmd.ExecuteNonQuery();
            con.Close();
        }

/*******Item Utilities************************************************************************************/

        //Select all items from inventory
        public List<Clubs> selectAllItems()
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From Clubs";

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader read = cmd.ExecuteReader();

            //Item List

            List<Clubs> clubs = new List<Clubs>();

            while (read.Read())
            {
                Clubs c = new Clubs(Convert.ToInt32(read["SKU"]),
                    Convert.ToDateTime(read["shipmentDate"]),
                    read["brand"].ToString(),
                    read["model"].ToString(),
                    read["clubType"].ToString(),
                    read["shaft"].ToString(),
                    read["numberOfClubs"].ToString(),
                    Convert.ToDouble(read["tradeInPrice"]),
                    Convert.ToDouble(read["premium"]),
                    Convert.ToDouble(read["wePay"]),
                    Convert.ToInt32(read["quantity"]),
                    Convert.ToDouble(read["extendedPrice"]),
                    Convert.ToDouble(read["retailPrice"]),
                    read["comments"].ToString(),
                    read["clubSpec"].ToString(),
                    read["shaftSpec"].ToString(),
                    read["shaftFlex"].ToString(),
                    read["dexterity"].ToString(),
                    read["destination"].ToString(),
                    Convert.ToBoolean(read["paid"]),
                    Convert.ToBoolean(read["received"]),
                    Convert.ToBoolean(read["gst"]),
                    Convert.ToBoolean(read["gst"]));

                clubs.Add(c);
            }

            con.Close();
            return clubs;
        }

        //Select specific item from inventory

        public List<Clubs> singleItemLookUp(int SKU)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select SKU, brand, model, clubType, shaft, numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice, clubSpec, shaftSpec, shaftFlex, dexterity From Item Where SKU = @SKU";
            cmd.Parameters.AddWithValue("SKU", SKU);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader read = cmd.ExecuteReader();

            //Item List

            List<Clubs> clubs = new List<Clubs>();

            while (read.Read())
            {
                Clubs c = new Clubs(Convert.ToInt32(read["SKU"]),
                    read["brand"].ToString(),
                    read["model"].ToString(),
                    read["clubType"].ToString(),
                    read["shaft"].ToString(),
                    read["numberOfClubs"].ToString(),
                    Convert.ToDouble(read["tradeInPrice"]),
                    Convert.ToDouble(read["premium"]),
                    Convert.ToDouble(read["wePay"]),
                    Convert.ToInt32(read["quantity"]),
                    Convert.ToDouble(read["extendedPrice"]),
                    Convert.ToDouble(read["retailPrice"]),
                    read["clubSpec"].ToString(),
                    read["shaftSpec"].ToString(),
                    read["shaftFlex"].ToString(),
                    read["dexterity"].ToString());

                clubs.Add(c);
            }

            con.Close();
            return clubs;
        }

        //Get item by ID for invoice process

        public List<Clubs> getItemByID(Int32 ItemNumber)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            //cmd.CommandText = "Select * From Inventory Where ItemNumber = @ItemNumber";
            cmd.CommandText = "Select sku , brand, model, clubType, shaft,numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice,  clubSpec, shaftSpec, shaftFlex, dexterity From Item Where SKU = @sku";
            cmd.Parameters.AddWithValue("sku", ItemNumber);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clubs> clubs = new List<Clubs>();

            while (reader.Read())
            {
                Clubs c = new Clubs
                (Convert.ToInt32(reader["sku"]),
                convertDBNullToString(reader["Brand"]).ToString(),
                reader["Model"].ToString(),
                reader["ClubType"].ToString(),
                reader["Shaft"].ToString(),
                reader["NumberOfClubs"].ToString(),
                Convert.ToDouble(reader["tradeInPrice"]),
                Convert.ToDouble(reader["premium"]),
                Convert.ToDouble(reader["wePay"]),
                Convert.ToInt32(reader["quantity"]),
                Convert.ToDouble(reader["extendedPrice"]),
                convertDBNullToDouble(reader["retailPrice"]),
                reader["ClubSpec"].ToString(),
                reader["ShaftSpec"].ToString(),
                reader["ShaftFlex"].ToString(),
                reader["Dexterity"].ToString()
                );


                clubs.Add(c);
            }
            conn.Close();
            return clubs;

        }

        public string convertDBNullToString(Object o)
        {
            if (o is DBNull)
                o = "";

            return o.ToString();

        }
        public double convertDBNullToDouble(Object o)
        {
            double dbl = 0.0;
            if (o is DBNull)
                dbl = 0.0;
            else
                dbl = Convert.ToDouble(o);

            return dbl;

        }

        public Clubs getItem(int SKU)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select SKU, brand, model, clubType, shaft, numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice, clubSpec, shaftSpec, shaftFlex, dexterity From Item Where SKU = @SKU";
            cmd.Parameters.AddWithValue("SKU", SKU);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader read = cmd.ExecuteReader();

            Clubs clubs = new Clubs();
            while (read.Read())
            {
                    clubs = new Clubs(Convert.ToInt32(read["SKU"]),
                    read["brand"].ToString(),
                    read["model"].ToString(),
                    read["clubType"].ToString(),
                    read["shaft"].ToString(),
                    read["numberOfClubs"].ToString(),
                    Convert.ToDouble(read["tradeInPrice"]),
                    Convert.ToDouble(read["premium"]),
                    Convert.ToDouble(read["wePay"]),
                    Convert.ToInt32(read["quantity"]),
                    Convert.ToDouble(read["extendedPrice"]),
                    Convert.ToDouble(read["retailPrice"]),
                    read["clubSpec"].ToString(),
                    read["shaftSpec"].ToString(),
                    read["shaftFlex"].ToString(),
                    read["dexterity"].ToString());
            }

            con.Close();
            return clubs;
        }


        //Export items table to excel file in users Downloads folder
        public void exportItems()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM item", sqlCon);
            DataTable dtMainSQLData = new DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new
            Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {
                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
            }
            //Get users profile, downloads folder path, and save to workstation
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            ExcelApp.ActiveWorkbook.SaveCopyAs(pathDownload + "\\Inventory-"+DateTime.Now.ToString("d MMM yyyy") +".xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        
        //Add single item into inventory
        public void addItem(Clubs c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "SET IDENTITY_INSERT Item ON; INSERT INTO Item(sku,shipmentDate, brand, model, clubType, shaft, numberOfClubs, tradeInPrice," + 
                "premium, wePay, quantity, extendedPrice, retailPrice, comments, clubSpec, shaftSpec,"+
                "shaftFlex, dexterity, destination, received, paid, gst, pst)"+
                "VALUES(@sku, @shipmentDate, @brand, @model, @clubType, @shaft, @numberOfClubs, @tradeInPrice, "+
                "@premium, @wePay, @quantity, @extendedPrice, @retailPrice, @comments, @clubSpec, @shaftSpec,"+
                "@shaftFlex, @dexterity, @destination, @received, @paid, @gst, @pst); SET IDENTITY_INSERT Item OFF;";
            cmd.Parameters.AddWithValue("sku", c.Sku);
            cmd.Parameters.AddWithValue("shipmentDate",c.ShipmentDate );
            cmd.Parameters.AddWithValue("brand", c.Brand);
            cmd.Parameters.AddWithValue("model", c.Model);
            cmd.Parameters.AddWithValue("clubType", c.ClubType);
            cmd.Parameters.AddWithValue("shaft", c.Shaft);
            cmd.Parameters.AddWithValue("numberOfClubs", c.NumberOfClubs);
            cmd.Parameters.AddWithValue("tradeInPrice", c.TradeInPrice);
            cmd.Parameters.AddWithValue("premium", c.Premium);
            cmd.Parameters.AddWithValue("wePay", c.WePay);
            cmd.Parameters.AddWithValue("quantity", c.Quantity);
            cmd.Parameters.AddWithValue("extendedPrice", c.ExtendedPrice);
            cmd.Parameters.AddWithValue("retailPrice", c.RetailPrice);
            cmd.Parameters.AddWithValue("comments", c.Comments);
            cmd.Parameters.AddWithValue("clubSpec", c.ClubSpec);
            cmd.Parameters.AddWithValue("shaftSpec", c.ShaftSpec);
            cmd.Parameters.AddWithValue("shaftFlex", c.ShaftFlex);
            cmd.Parameters.AddWithValue("dexterity", c.Dexterity);
            cmd.Parameters.AddWithValue("destination", c.Destination);
            cmd.Parameters.AddWithValue("received", c.Received);
            cmd.Parameters.AddWithValue("paid", c.Paid);
            cmd.Parameters.AddWithValue("gst", c.Gst);
            cmd.Parameters.AddWithValue("pst", c.Pst);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Update item in inventory
        public void updateItemInvoice(Clubs c)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Item SET  quantityInOrder = @quantityInOrder,brand = @brand, model = @model," +
                "clubType = @clubType, shaft = @shaft, numberOfClubs = @numberOfClubs, tradeInPrice = @tradeInPrice," +
                "premium = @premium, wePay = @wePay, quantity = @quantity, extendedPrice = @extendedPrice," +
                "retailPrice = @retailPrice, clubSpec = @clubSpec, shaftSpec = @shaftSpec," +
                "shaftFlex = @shaftFlex, dexterity = @dexterity, gst = @gst, pst = @pst WHERE sku = @sku";

            cmd.Parameters.AddWithValue("@sku", c.Sku);
            cmd.Parameters.AddWithValue("@quantityInOrder", c.QuantityInOrder);
            cmd.Parameters.AddWithValue("@brand", c.Brand);
            cmd.Parameters.AddWithValue("@model", c.Model);
            cmd.Parameters.AddWithValue("@clubType", c.ClubType);
            cmd.Parameters.AddWithValue("@shaft", c.Shaft);
            cmd.Parameters.AddWithValue("@numberOfClubs", c.NumberOfClubs);
            cmd.Parameters.AddWithValue("@tradeInPrice", c.TradeInPrice);
            cmd.Parameters.AddWithValue("@premium", c.Premium);
            cmd.Parameters.AddWithValue("@wePay", c.WePay);
            cmd.Parameters.AddWithValue("@quantity", c.Quantity);
            cmd.Parameters.AddWithValue("@extendedPrice", c.ExtendedPrice);
            cmd.Parameters.AddWithValue("@retailPrice", c.RetailPrice);
            cmd.Parameters.AddWithValue("@clubSpec", c.ClubSpec);
            cmd.Parameters.AddWithValue("@shaftSpec", c.ShaftSpec);
            cmd.Parameters.AddWithValue("@shaftFlex", c.ShaftFlex);
            cmd.Parameters.AddWithValue("@dexterity", c.Dexterity);
            cmd.Parameters.AddWithValue("@gst", c.Gst);
            cmd.Parameters.AddWithValue("@pst", c.Pst);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Update item in inventory
        public void updateItem(Clubs c)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();       
            cmd.CommandText = "UPDATE Item SET shipmentDate = @shipmentDate, brand = @brand, model = @model,"+ 
                "clubType = @clubType, shaft = @shaft, numberOfClubs = @numberOfClubs, tradeInPrice = @tradeInPrice,"+
                "premium = @premium, wePay = @wePay, quantity = @quantity, extendedPrice = @extendedPrice,"+ 
                "retailPrice = @retailPrice, comments = @comments, clubSpec = @clubSpec, shaftSpec = @shaftSpec,"+ 
                "shaftFlex = @shaftFlex, dexterity = @dexterity, destination = @destination, received = @received, paid = @paid, gst = @gst, pst = @pst WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", c.Sku);
            cmd.Parameters.AddWithValue("@shipmentDate", c.ShipmentDate);
            cmd.Parameters.AddWithValue("@brand", c.Brand);
            cmd.Parameters.AddWithValue("@model", c.Model);
            cmd.Parameters.AddWithValue("@clubType", c.ClubType);
            cmd.Parameters.AddWithValue("@shaft", c.Shaft);
            cmd.Parameters.AddWithValue("@numberOfClubs", c.NumberOfClubs);
            cmd.Parameters.AddWithValue("@tradeInPrice", c.TradeInPrice);
            cmd.Parameters.AddWithValue("@premium", c.Premium);
            cmd.Parameters.AddWithValue("@wePay", c.WePay);
            cmd.Parameters.AddWithValue("@quantity", c.Quantity);
            cmd.Parameters.AddWithValue("@extendedPrice", c.ExtendedPrice);
            cmd.Parameters.AddWithValue("@retailPrice", c.RetailPrice);
            cmd.Parameters.AddWithValue("@comments", c.Comments);
            cmd.Parameters.AddWithValue("@clubSpec", c.ClubSpec);
            cmd.Parameters.AddWithValue("@shaftSpec", c.ShaftSpec);
            cmd.Parameters.AddWithValue("@shaftFlex", c.ShaftFlex);
            cmd.Parameters.AddWithValue("@dexterity", c.Dexterity);
            cmd.Parameters.AddWithValue("@destination", c.Destination);
            cmd.Parameters.AddWithValue("@received", c.Received);
            cmd.Parameters.AddWithValue("@paid", c.Paid);
            cmd.Parameters.AddWithValue("@gst", c.Gst);
            cmd.Parameters.AddWithValue("@pst", c.Pst);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateItemQuantity(int quantity, int sku)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Item SET quantity = quantity + @quantity WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", sku);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //Delete item from inventory
        public void deleteItem(int sku)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Item WHERE sku=@sku";
            cmd.Parameters.AddWithValue("sku", sku);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

/*******Invoice Utilities************************************************************************************/

        public int getInvoiceID(DateTime saleDate)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select invoiceID FROM Invoice Where saleDate = @saleDate";
            cmd.Parameters.AddWithValue("saleDate", saleDate);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
           // Invoice invoice = new Invoice();
            int invoiceID = 0;
            while (reader.Read())
            {
               
                    invoiceID = Convert.ToInt32(reader["invoiceID"]);
                
            }
            conn.Close();
            return invoiceID;
        }

        //Get Invoice by invoiceID and return the invoice object
        public Invoice getInvoice(int invoiceID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Invoice WHERE invoiceID = @invoiceID";
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Invoice i = new Invoice();
            //int InvoiceID, int CustomerID, double GST, double PST, double PaymentTotal,
            //double SubTotal, double Total, double Discount, double TradeIn, int PaymentID, int StateProveID, bool Posted,
            //bool InProcess, DateTime PostedDate, DateTime DateModified, DateTime SaleDate

            while (reader.Read()) 
            {
                i = new Invoice(Convert.ToInt32(reader["invoiceID"]), Convert.ToDouble(reader["gst"]),
                  Convert.ToDouble(reader["pst"]), Convert.ToDouble(reader["subTotal"]), Convert.ToDouble(reader["total"]),
                   Convert.ToDouble(reader["paymentTotal"]), Convert.ToInt32(reader["stateProvID"]));
            }
            con.Close();
            return i;
        }

        public List<Invoice> getInvoiceBySaleDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT invoiceID, tradeIn, subTotal, gst, pst, total, paymentID, posted, saleDate FROM Invoice WHERE saleDate BETWEEN @StartDate AND @EndDate AND posted = 0";
            cmd.Parameters.AddWithValue("StartDate", StartDate);
            cmd.Parameters.AddWithValue("EndDate", EndDate);
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Invoice> i = new List<Invoice>();
            while (reader.Read())
            {
                Invoice inv = new Invoice(Convert.ToInt32(reader["invoiceID"]),
                   Convert.ToDouble(reader["tradeIn"]),
                   Convert.ToDouble(reader["subTotal"]),
                   Convert.ToDouble(reader["gst"]),
                   Convert.ToDouble(reader["pst"]),
                   Convert.ToDouble(reader["total"]),
                   Convert.ToBoolean(reader["posted"]),
                   Convert.ToInt32(reader["paymentID"]),
                   Convert.ToDateTime(reader["SaleDate"].ToString()));

                i.Add(inv);
            }

            con.Close();

            return i;
        }

              
        //public void updateReturnToInvoice(int invoiceID, double gstRefund, double pstRefund, double retailPrice, double totalRefund)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = "UPDATE Invoice SET gst = gst - @gst, pst = pst - @pst, subtotal = subtotal - @retailPrice,"+
        //        "total = total - @totalRefund, paymentTotal = paymentTotal - @totalRefund WHERE invoiceID = @invoiceID";
        //    cmd.Parameters.AddWithValue("invoiceID", invoiceID);
        //    cmd.Parameters.AddWithValue("gst", gstRefund);
        //    cmd.Parameters.AddWithValue("pst", pstRefund);
        //    cmd.Parameters.AddWithValue("retailPrice", retailPrice);
        //    cmd.Parameters.AddWithValue("totalRefund", totalRefund);
        //    //Declare and open connection
        //    cmd.Connection = con;
        //    con.Open();
        //    //Execute Insert
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        public void addInvoice(Invoice i)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Invoice( customerID, gst, pst, paymentTotal, balance, subTotal, total, discount, tradeIn, paymentID, stateprovID, posted, inProcess, saleDate) VALUES ( @customerID, @gst, @pst, @paymentTotal, @balance, @subTotal, @total, @discount, @tradeIn, @paymentID, @stateprovID, @posted, @inProcess, @saleDate)";
         
            cmd.Parameters.AddWithValue("customerID", i.customerId);
            cmd.Parameters.AddWithValue("gst", i.gst);
            cmd.Parameters.AddWithValue("pst", i.pst);
            cmd.Parameters.AddWithValue("paymentTotal", i.paymentTotal);
            cmd.Parameters.AddWithValue("balance", i.balance);
            cmd.Parameters.AddWithValue("subTotal", i.subTotal);
            cmd.Parameters.AddWithValue("total", i.total);
            cmd.Parameters.AddWithValue("discount", i.discount);
            cmd.Parameters.AddWithValue("tradeIn", i.tradeIn);
            cmd.Parameters.AddWithValue("paymentID", i.paymentID);
            cmd.Parameters.AddWithValue("stateprovID", i.stateprovID);
            cmd.Parameters.AddWithValue("posted", i.posted);
            cmd.Parameters.AddWithValue("inProcess", i.inProcess);
            cmd.Parameters.AddWithValue("saleDate", i.saleDate);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();         
        }


        //Sets affected invoices to posted and replaces the null value with a posted date.
        public void postInvoices(int invoiceID, DateTime PostedDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Invoice SET posted = 1, postedDate = @PostedDate WHERE invoiceID = @invoiceID";
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);
            cmd.Parameters.AddWithValue("postedDate", PostedDate);          
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute update
            cmd.ExecuteNonQuery();
            con.Close();
        }
            
/*******Sale Utilities************************************************************************************/

            //Get sale by invoiceID
        public void getSaleByInvoiceIDAndSKU(int invoiceID, int SKU)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sale WHERE invoiceID = @invoiceID AND SKU = @SKU";
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Update
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void addSale(Sale s)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Sale( invoiceID, sku, quantity) VALUES (@invoiceID, @sku, @quantity)";

            cmd.Parameters.AddWithValue("invoiceID", s.invoiceId);
            cmd.Parameters.AddWithValue("sku", s.sku);
            cmd.Parameters.AddWithValue("quantity", s.quantity);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void returnUpdatedQuantity(int sku, int quantityInOrder)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Item SET quantity = quantity - @quantityInOrder WHERE sku = @sku";
            cmd.Parameters.AddWithValue("sku", sku);
            cmd.Parameters.AddWithValue("quantityInOrder", quantityInOrder);

            cmd.Connection = con;
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Delete sale of specific item on an invoice
        public void deleteSale(int invoiceID, int sku)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            //Delete item from sale table
            cmd.CommandText = "DELETE FROM Sale WHERE invoiceID = @invoiceID AND sku=@sku";
            cmd.Parameters.AddWithValue("sku", sku);
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();

            //Execute Update
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Get Sale object for a specific item on an invoice
        public List<Sale> getSale(int invoiceID, int sku)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            //Delete item from sale table
            cmd.CommandText = "Select * FROM Sale WHERE invoiceID = @invoiceID AND sku=@sku";
            cmd.Parameters.AddWithValue("sku", sku);
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            List<Sale> s = new List<Sale>();
            //Initialize SQLdatareader and initialize new sale object with results
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                s.Add(new Sale(Convert.ToInt32(reader["invoiceID"]), Convert.ToInt32(reader["sku"]),
                Convert.ToInt32(reader["quantity"])));
            }
            //Close Connection
            con.Close();

            //return sale object
            return s;
        }

        //Get Sale object for a specific item on an invoice
        public Sale getSaleByInvAndSKU(int invoiceID, int sku)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            //Delete item from sale table
            cmd.CommandText = "Select * FROM Sale WHERE invoiceID = @invoiceID AND sku=@sku";
            cmd.Parameters.AddWithValue("sku", sku);
            cmd.Parameters.AddWithValue("invoiceID", invoiceID);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            Sale s = new Sale();
            //Initialize SQLdatareader and initialize new sale object with results
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                s = (new Sale(Convert.ToInt32(reader["invoiceID"]), Convert.ToInt32(reader["sku"]),
                Convert.ToInt32(reader["quantity"])));
            }
            //Close Connection
            con.Close();

            //return sale object
            return s;
        }

        /*******Tax Utilities************************************************************************************/

        public List<Tax> getTaxes()
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [stateProvID],[stateProvDesc],[gst],[pst] FROM[SweetSpotDev].[dbo].[StateProvLT]";
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            List<Tax> tax = new List<Tax>();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Tax t = new Tax(Convert.ToDouble(read["gst"]),
                    Convert.ToDouble(read["pst"]),
                    Convert.ToInt32(read["stateProvID"]));
                tax.Add(t);
            }
            con.Close();
            return tax;
        }

       
        //    public void updateTax(int regionID, double gst, double pst)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = "UPDATE StateProvLT SET gst = @gst, pst = @pst WHERE stateProvID = @stateProvID";
        //    cmd.Parameters.AddWithValue("@stateProvID", regionID);
        //    cmd.Parameters.AddWithValue("@gst", gst);
        //    cmd.Parameters.AddWithValue("@pst", pst);
          
        //    //Declare and open connection
        //    cmd.Connection = con;
        //    con.Open();

        //    //Execute Insert
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public Tax getTaxByStateProvID(int stateProvID)
        //{
        //    //New command
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT gst, pst FROM StateProvLT WHERE stateProvID = @stateProvID";
        //    cmd.Parameters.AddWithValue("stateProvID", stateProvID);
            
        //    //Declare and open connection
        //    cmd.Connection = con;
        //    con.Open();
        //    Tax t = new Tax();
        //    SqlDataReader read = cmd.ExecuteReader();
        //    while (read.Read())
        //    {
        //            t = new Tax(Convert.ToDouble(read["gst"]),
        //            Convert.ToDouble(read["pst"]));
        //    }
        //    con.Close();
        //    return t;
        //}
		
		 //*******Report Utilities************************************************************************************/

		//Export customer table to excel file in users Downloads folder
        public void exportCustomers()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customer", sqlCon);
            DataTable dtMainSQLData = new DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new
            Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {
                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
            }
            //Get users profile, downloads folder path, and save to workstation
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            ExcelApp.ActiveWorkbook.SaveCopyAs(pathDownload + "\\Customers-" + DateTime.Now.ToString("d MMM yyyy") + ".xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        //Export Inventory Sales to excel file in users Downloads folder
        public void exportInvoices(DateTime startDate, DateTime endDate)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string sqlStatement = "SELECT Invoice.invoiceID, Item.SKU, Sale.quantity, Item.brand, Item.model, Item.clubType, Item.shaft, Item.numberOfClubs, Item.clubSpec, Item.shaftSpec, Item.shaftFlex, Item.dexterity, Item.wePay, Item.retailPrice FROM Invoice INNER JOIN Customer ON Invoice.customerID = Customer.customerId INNER JOIN Sale ON Invoice.invoiceID = Sale.invoiceID INNER JOIN Item ON Sale.SKU = Item.SKU WHERE (Invoice.saleDate BETWEEN '" + startDate + "' AND '" + endDate + "')";
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, sqlCon);
            DataTable dtMainSQLData = new DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new
            Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {
                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
            }
            //Get users profile, downloads folder path, and save to workstation
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            ExcelApp.ActiveWorkbook.SaveCopyAs(pathDownload + "\\Inventory Sales-" + DateTime.Now.ToString("d MMM yyyy") + ".xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        //Export Invoice table to excel 
        public void exportInvoices()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string sqlStatement = "SELECT * FROM Invoice";
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, sqlCon);
            DataTable dtMainSQLData = new DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new
            Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {
                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
            }
            //Get users profile, downloads folder path, and save to workstation
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            ExcelApp.ActiveWorkbook.SaveCopyAs(pathDownload + "\\Inventory-" + DateTime.Now.ToString("d MMM yyyy") + ".xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }


        //************************************Inventory Sales Utilities********************************************/

        //This method will select all invoices involved in a sale between the specified dates and encapsulated them in a list.
        public List<InvSale> selectAllInventorySales(DateTime startDate, DateTime endDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Invoice.invoiceID, Item.SKU, Sale.quantity, Item.brand, Item.model, Item.clubType, Item.shaft, Item.numberOfClubs, Item.clubSpec, Item.shaftSpec, Item.shaftFlex, Item.dexterity, Item.wePay, Item.retailPrice FROM Invoice INNER JOIN Customer ON Invoice.customerID = Customer.customerId INNER JOIN Sale ON Invoice.invoiceID = Sale.invoiceID INNER JOIN Item ON Sale.SKU = Item.SKU WHERE (Invoice.saleDate BETWEEN @startDate AND @endDate)";
            cmd.Parameters.AddWithValue("startDate", startDate);
            cmd.Parameters.AddWithValue("endDate", endDate);

            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<InvSale> ivs = new List<InvSale>();
            while (reader.Read())
            {
                InvSale isl = new InvSale(Convert.ToInt32(reader["invoiceID"]),
                    Convert.ToInt32(reader["sku"]),
                    Convert.ToInt32(reader["quantity"]),
                    Convert.ToString(reader["brand"]),
                    Convert.ToString(reader["model"]),
                    Convert.ToString(reader["clubType"]),
                    Convert.ToString(reader["shaft"]),
                    Convert.ToString(reader["numberOfClubs"]),
                    Convert.ToString(reader["clubSpec"]),
                    Convert.ToString(reader["shaftSpec"]),
                    Convert.ToString(reader["shaftFlex"]),
                    Convert.ToString(reader["dexterity"]),
                    Convert.ToDouble(reader["wePay"]),
                    Convert.ToDouble(reader["retailPrice"]));

                ivs.Add(isl);
            }

            con.Close();
            return ivs;
           
        }

        
    }
}