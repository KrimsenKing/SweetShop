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
using System.Configuration;
using SweetSpotProShop;
using System.Collections;

namespace SweetShop
{
    public class SweetShopManager
    {
        private string connectionString;
        //Using Nathan and Tyler created
        public SweetShopManager()
        {

            connectionString = ConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString;
        }

        /*******Customer Utilities************************************************************************************/

        //Retrieves Customer from search parameters Nathan and Tyler created
        public List<Customer> GetCustomerfromSearch(String searchField)
        {
            try
            {
                //Declares space for connection string and new command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "Select * From tbl_customers Where (firstName + ' ' + lastName) Like '%@searchField1%' or (primaryPhoneINT + ' ' + secondaryPhoneINT) like '%@searchField2%' order by firstName asc";
                cmd.CommandText = "Select * From tbl_customers Where Concat(firstName,lastName) Like '%" + searchField + "%' or Concat(primaryPhoneINT,secondaryPhoneINT) like '%" + searchField + "%' order by firstName asc";
                //cmd.Parameters.AddWithValue("searchField1", searchField);
                //cmd.Parameters.AddWithValue("searchField2", searchField);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //New List for Customer

                List<Customer> customer = new List<Customer>();

                //Begin reading
                while (reader.Read())
                {
                    Customer c = new Customer(Convert.ToInt32(reader["custID"]),
                        reader["firstName"].ToString(),
                        reader["lastName"].ToString(),
                        reader["primaryAddress"].ToString(),
                        reader["secondaryAddress"].ToString(),
                        reader["primaryPhoneINT"].ToString(),
                        reader["secondaryPhoneINT"].ToString(),
                        reader["billingAddress"].ToString(),
                        reader["email"].ToString(),
                        reader["city"].ToString(),
                        Convert.ToInt32(reader["provStateID"]),
                        Convert.ToInt32(reader["country"]),
                        reader["postZip"].ToString());

                    customer.Add(c);

                }

                con.Close();
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        //Retreive Customer from custID Nathan and Tyler created
        public Customer GetCustomerbyCustomerNumber(int custNum)
        {
            try
            {
                //Declares space for connection string and new command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * From tbl_customers Where custID = @custNum;";
                cmd.Parameters.AddWithValue("custNum", custNum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //New Customer
                Customer customer = new Customer();

                //Begin reading
                while (reader.Read())
                {
                    Customer c = new Customer(Convert.ToInt32(reader["custID"]),
                        reader["firstName"].ToString(),
                        reader["lastName"].ToString(),
                        reader["primaryAddress"].ToString(),
                        reader["secondaryAddress"].ToString(),
                        reader["primaryPhoneINT"].ToString(),
                        reader["secondaryPhoneINT"].ToString(),
                        reader["billingAddress"].ToString(),
                        reader["email"].ToString(),
                        reader["city"].ToString(),
                        Convert.ToInt32(reader["provStateID"]),
                        Convert.ToInt32(reader["country"]),
                        reader["postZip"].ToString());

                    customer = c;
                }

                con.Close();
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        //Add Customer Nathan and Tyler created
        public int addCustomer(Customer c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into tbl_customers (firstName, lastName, primaryAddress,"
                + " secondaryAddress, primaryPhoneINT, secondaryPhoneINT, billingAddress, email,"
                + " city, provStateID, country, postZip) Values (@FirstName, @LastName, @primaryAddress,"
                + " @secondaryAddress, @primaryPhoneNumber, @secondaryPhoneNumber, @billingAddress,"
                + " @Email, @City, @Province, @Country, @PostalCode)";
            cmd.Parameters.AddWithValue("FirstName", c.firstName);
            cmd.Parameters.AddWithValue("LastName", c.lastName);
            cmd.Parameters.AddWithValue("primaryAddress", c.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", c.secondaryAddress);
            cmd.Parameters.AddWithValue("billingAddress", c.billingAddress);
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

            return returnCustomerNumber(c);

        }

        //Nathan and Tyler created
        public int returnCustomerNumber(Customer c)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select custID From tbl_customers Where firstName = @FirstName and lastName = @LastName and primaryAddress = @primaryAddress and secondaryAddress = @secondaryAddress and primaryPhoneINT = @primaryPhoneNumber and secondaryPhoneINT = @secondaryPhoneNumber and billingAddress = @BillingAddress and email = @Email and city = @City and provStateID = @Province and country = @Country and postZip = @PostalCode;";
            cmd.Parameters.AddWithValue("FirstName", c.firstName);
            cmd.Parameters.AddWithValue("LastName", c.lastName);
            cmd.Parameters.AddWithValue("primaryAddress", c.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", c.secondaryAddress);
            cmd.Parameters.AddWithValue("primaryPhoneNumber", c.primaryPhoneNumber);
            cmd.Parameters.AddWithValue("secondaryPhoneNumber", c.secondaryPhoneNumber);
            cmd.Parameters.AddWithValue("BillingAddress", c.billingAddress);
            cmd.Parameters.AddWithValue("Email", c.email);
            cmd.Parameters.AddWithValue("City", c.city);
            cmd.Parameters.AddWithValue("Province", c.province);
            cmd.Parameters.AddWithValue("Country", c.country);
            cmd.Parameters.AddWithValue("PostalCode", c.postalCode);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //New Customer number
            int custNum=0;

            //Begin reading
            while (reader.Read())
            {
                custNum = Convert.ToInt32(reader["custID"]);
            }
            con.Close();
            return custNum;
        }

        //Update Customer Nathan and Tyler Created
        public void updateCustomer(Customer c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Update tbl_customers Set firstName = @FirstName, lastName = @LastName, primaryAddress = @primaryAddress,"
                + " secondaryAddress = @secondaryAddress, primaryPhoneINT = @primaryPhoneNumber, secondaryPhoneINT = @secondaryPhoneNumber,"
                + " billingAddress = @BillingAddress, email = @Email, city = @City, provStateID = @Province, country = @Country,"
                + " postZip = @PostalCode Where custID = @CustomerID";
            cmd.Parameters.AddWithValue("CustomerID", c.customerId);
            cmd.Parameters.AddWithValue("FirstName", c.firstName);
            cmd.Parameters.AddWithValue("LastName", c.lastName);
            cmd.Parameters.AddWithValue("primaryAddress", c.primaryAddress);
            cmd.Parameters.AddWithValue("secondaryAddress", c.secondaryAddress);
            cmd.Parameters.AddWithValue("primaryPhoneNumber", c.primaryPhoneNumber);
            cmd.Parameters.AddWithValue("secondaryPhoneNumber", c.secondaryPhoneNumber);
            cmd.Parameters.AddWithValue("BillingAddress", c.billingAddress);
            cmd.Parameters.AddWithValue("Email", c.email);
            cmd.Parameters.AddWithValue("City", c.city);
            cmd.Parameters.AddWithValue("Province", c.province);
            cmd.Parameters.AddWithValue("Country", c.country);
            cmd.Parameters.AddWithValue("PostalCode", c.postalCode);

            //Declare and open connection
            cmd.Connection = con;
            con.Open();

            //Execute Update
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*******Item Utilities************************************************************************************/

        //Select all items from inventory **possible deletion
        public List<Clubs> selectAllItems()
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From Clubs";

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            //Item List

            List<Clubs> clubs = new List<Clubs>();

            while (reader.Read())
            {
                Clubs c = new Clubs(Convert.ToInt32(reader["SKU"]),
                    Convert.ToInt32(reader["brandID"]),
                    Convert.ToInt32(reader["modelID"]),
                    Convert.ToInt32(reader["typeID"]),
                    reader["clubType"].ToString(),
                    reader["shaft"].ToString(),
                    reader["numberOfClubs"].ToString(),
                    Convert.ToDouble(reader["premium"]),
                    Convert.ToDouble(reader["cost"]),
                    Convert.ToDouble(reader["price"]),
                    Convert.ToInt32(reader["quantity"]),
                    reader["clubSpec"].ToString(),
                    reader["shaftSpec"].ToString(),
                    reader["shaftFlex"].ToString(),
                    reader["dexterity"].ToString(),
                    Convert.ToBoolean(reader["used"]),
                    reader["comments"].ToString());

                clubs.Add(c);
            }

            con.Close();
            return clubs;
        }

        //Robust search through inventory Nathan and Tyler created
        public List<Items> GetItemfromSearch(string itemSearched, string itemType)
        {
            ArrayList strText = new ArrayList();

            int numFields = itemSearched.Split(' ').Length;

            if (numFields > 1)
            {
                for (int i = 0; i < numFields; i++)
                {
                    strText.Add(itemSearched.Split(' ')[i]);
                }
            }
            else
            {
                strText.Add(itemSearched);
            }

            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            //If type is clubs perform this search

            //Item List

            List<Items> item = new List<Items>();
            //Open Database Connection
            cmd.Connection = con;
            con.Open();
            for (int i = 0; i < numFields; i++)
            {

                if (itemType == "Clubs")
                {
                    if (i == 0)
                    {
                        cmd.CommandText = "Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                        + " modelID in (Select modelID from tbl_model where modelName like '%" + strText[i] + "%') or "
                                        + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                        + " concat(clubType, shaft, dexterity) like '%" + strText[i] + "%'";
                    }
                    else
                    {
                        cmd.CommandText = cmd.CommandText + " Intersect (Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                        + " modelID in (Select modelID from tbl_model where modelName like '%" + strText[i] + "%') or "
                                        + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                        + " concat(clubType, shaft, dexterity) like '%" + strText[i] + "%')";
                    }
                }
                // if type is accessories perform this search
                else if (itemType == "Accessories")
                {
                    if (i == 0)
                    {
                        cmd.CommandText = "Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                    + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                    + " concat(size, colour) like '%" + strText[i] + "%'";
                    }
                    else
                    {
                        cmd.CommandText = cmd.CommandText + "Intersect (Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                    + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                    + " concat(size, colour) like '%" + strText[i] + "%')";
                    }
                }
                //if type is clothing perform this search
                else if (itemType == "Clothing")
                {
                    if (i == 0)
                    {
                        cmd.CommandText = "Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                    + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                    + " concat(size, colour, gender, style) like '%" + strText[i] + "%'";
                    }
                    else
                    {
                        cmd.CommandText = cmd.CommandText + "Intersect (Select * from tbl_" + itemType + " where sku like '%" + strText[i] + "%' or "
                                    + " brandID in (Select brandID from tbl_brand where brandName like '%" + strText[i] + "%') or "
                                    + " concat(size, colour, gender, style) like '%" + strText[i] + "%')";
                    }
                }
            }
            cmd.CommandText = cmd.CommandText + ";";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string brand = null;
                string model = null;
                string description = null;

                ItemDataUtilities idu = new ItemDataUtilities();
                //if brand is not null return brand description
                if (reader["brandID"] != null)
                {
                    brand = idu.brandType(Convert.ToInt32(reader["brandID"]));
                }
                //if search type is clubs enter here for model and description builder
                if (itemType == "Clubs")
                {
                    //if model is not null return model description
                    if (reader["modelID"] != null)
                    {
                        model = idu.modelType(Convert.ToInt32(reader["modelID"]));
                    }
                    //create string for a club description
                    description = brand + " " + model + " " + reader["clubType"].ToString() + " " + reader["shaft"].ToString() + " "
                    + reader["numberOfClubs"].ToString() + " " + reader["dexterity"].ToString();
                }
                //if search type is accessories create accessories description
                else if (itemType == "Accessories")
                {
                    description = brand + " " + reader["size"].ToString() + " " + reader["colour"].ToString();
                }
                //if search type is clothing create clothing description
                else if (itemType == "Clothing")
                {
                    description = brand + " " + reader["size"].ToString() + " " + reader["colour"].ToString() + " "
                    + reader["gender"].ToString() + " " + reader["style"].ToString();
                }
                //enter all returned items into item list for display
                Items j = new Items(Convert.ToInt32(reader["sku"]),
                    description,
                    Convert.ToInt32(reader["quantity"]),
                    Convert.ToDouble(reader["price"]),
                    Convert.ToDouble(reader["cost"]));

                item.Add(j);

            }

            con.Close();
            return item;
        }

        //Select specific item from inventory Nathan and Tyler created
        public Clubs singleItemLookUp(int sku)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select brandID, modelID, clubType, shaft, numberOfClubs, premium, cost, price, quantity, clubSpec,"
                + " shaftSpec, shaftFlex, dexterity, used, comments From tbl_clubs Where sku = @sku";
            cmd.Parameters.AddWithValue("sku", sku);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            //Item List

            Clubs clubs = new Clubs();

            while (reader.Read())
            {
                clubs.sku = Convert.ToInt32(reader["sku"]);
                clubs.brandID = Convert.ToInt32(reader["brandID"]);
                clubs.modelID = Convert.ToInt32(reader["model"]);
                clubs.clubType = reader["clubType"].ToString();
                clubs.shaft = reader["shaft"].ToString();
                clubs.numberOfClubs = reader["numberOfClubs"].ToString();
                clubs.premium = Convert.ToDouble(reader["premium"]);
                clubs.cost = Convert.ToDouble(reader["cost"]);
                clubs.price = Convert.ToDouble(reader["price"]);
                clubs.quantity = Convert.ToInt32(reader["quantity"]);
                clubs.clubSpec = reader["clubSpec"].ToString();
                clubs.shaftSpec = reader["shaftSpec"].ToString();
                clubs.shaftFlex = reader["shaftFlex"].ToString();
                clubs.dexterity = reader["dexterity"].ToString();
                clubs.used = Convert.ToBoolean(reader["used"]);
                clubs.comments = reader["comments"].ToString();
            }
            con.Close();
            return clubs;
        }
        //Adds new Item to tables Nathan created
        public int addItem(Object o)
        {
            if(o is Clubs)
            {
                Clubs c = o as Clubs;
                addClub(c);
            }
            else if(o is Accessories)
            {
                Accessories a = o as Accessories;
                addAccessory(a);
            }
            else if(o is Clothing)
            {
                Clothing cl = o as Clothing;
                addClothing(cl);
            }
            return returnItemNumber(o);
        }
        //returns sku number after adding to reload page with new item Nathan created
        public int returnItemNumber(Object o)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            if (o is Clubs){
                Clubs c = o as Clubs;
                cmd.CommandText = "Select sku From tbl_clubs Where brandID = @brandID and modelID = @modelID and clubType = @clubType and "
                    + " shaft = @shaft and numberOfClubs = @numberOfClubs and premium = @premium and cost = @cost and price = @price and "
                    + " quantity = @quantity and clubSpec = @clubSpec and shaftSpec = @shaftSpec and shaftFlex = @shaftFlex and "
                    + " dexterity = @dexterity and  used = @used and typeID = @typeID and comments = @comments)";
                cmd.Parameters.AddWithValue("brandID", c.brandID);
                cmd.Parameters.AddWithValue("modelID", c.modelID);
                cmd.Parameters.AddWithValue("clubType", c.clubType);
                cmd.Parameters.AddWithValue("shaft", c.shaft);
                cmd.Parameters.AddWithValue("numberOfClubs", c.numberOfClubs);
                cmd.Parameters.AddWithValue("premium", c.premium);
                cmd.Parameters.AddWithValue("cost", c.cost);
                cmd.Parameters.AddWithValue("price", c.price);
                cmd.Parameters.AddWithValue("quantity", c.quantity);
                cmd.Parameters.AddWithValue("clubSpec", c.clubSpec);
                cmd.Parameters.AddWithValue("shaftSpec", c.shaftSpec);
                cmd.Parameters.AddWithValue("shaftFlex", c.shaftFlex);
                cmd.Parameters.AddWithValue("dexterity", c.dexterity);
                cmd.Parameters.AddWithValue("used", c.used);
                cmd.Parameters.AddWithValue("typeID", c.typeID);
                cmd.Parameters.AddWithValue("comments", c.comments);
            }else if(o is Accessories){
                Accessories a = o as Accessories;
                cmd.CommandText = "Select sku From tbl_accessories Where brandID = @brandID and size = @size and color = @color and"
                    + " price = @price and cost = @cost and quantity = @quantity)";
                cmd.Parameters.AddWithValue("brandID", a.brandID);
                cmd.Parameters.AddWithValue("size", a.size);
                cmd.Parameters.AddWithValue("color", a.color);
                cmd.Parameters.AddWithValue("price", a.price);
                cmd.Parameters.AddWithValue("cost", a.cost);
                cmd.Parameters.AddWithValue("quantity", a.quantity);
            } else if(o is Clothing){
                Clothing c = o as Clothing;
                cmd.CommandText = "Select sku From tbl_clothing Where brandID = @brandID and size = @size and color = @color and"
                    + " gender = @gender and style = @style and price = @price and cost = @cost and quantity = @quantity)";
                cmd.Parameters.AddWithValue("brandID", c.brandID);
                cmd.Parameters.AddWithValue("size", c.size);
                cmd.Parameters.AddWithValue("color", c.color);
                cmd.Parameters.AddWithValue("gender", c.gender);
                cmd.Parameters.AddWithValue("style", c.style);
                cmd.Parameters.AddWithValue("price", c.price);
                cmd.Parameters.AddWithValue("cost", c.cost);
                cmd.Parameters.AddWithValue("quantity", c.quantity);
            }

            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            SqlDataReader reader = cmd.ExecuteReader();
            //New sku number
            int sku = 0;
            //Begin reading
            while (reader.Read())
            {
                sku = Convert.ToInt32(reader["sku"]);
            }
            con.Close();
            return sku;
        }
        //These three actully add the item to specific tables Nathan created
        public void addClub(Clubs c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into tbl_clubs (brandID, modelID, clubType, shaft, numberOfClubs,"
                + " premium, cost, price, quantity, clubSpec, shaftSpec, shaftFlex, dexterity, used, typeID, comments)"
                + " Values (@brandID, @modelID, @clubType, @shaft, @numberOfClubs, @premium, @cost, @price,"
                + " @quantity, @clubSpec, @shaftSpec, @shaftFlex, @dexterity, @used, @typeID, @comments)";
            cmd.Parameters.AddWithValue("brandID", c.brandID);
            cmd.Parameters.AddWithValue("modelID", c.modelID);
            cmd.Parameters.AddWithValue("clubType", c.clubType);
            cmd.Parameters.AddWithValue("shaft", c.shaft);
            cmd.Parameters.AddWithValue("numberOfClubs", c.numberOfClubs);
            cmd.Parameters.AddWithValue("premium", c.premium);
            cmd.Parameters.AddWithValue("cost", c.cost);
            cmd.Parameters.AddWithValue("price", c.price);
            cmd.Parameters.AddWithValue("quantity", c.quantity);
            cmd.Parameters.AddWithValue("clubSpec", c.clubSpec);
            cmd.Parameters.AddWithValue("shaftSpec", c.shaftSpec);
            cmd.Parameters.AddWithValue("shaftFlex", c.shaftFlex);
            cmd.Parameters.AddWithValue("dexterity", c.dexterity);
            cmd.Parameters.AddWithValue("used", c.used);
            cmd.Parameters.AddWithValue("typeID", c.typeID);
            cmd.Parameters.AddWithValue("comments", c.comments);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addAccessory(Accessories a)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into tbl_accessories (size, color, price, cost, brandID, quantity, typeID)"
                + " Values (@size, @color, @price, @cost, @brandID, @quantity, @typeID)";
            cmd.Parameters.AddWithValue("size", a.size);
            cmd.Parameters.AddWithValue("color", a.color);
            cmd.Parameters.AddWithValue("price", a.price);
            cmd.Parameters.AddWithValue("cost", a.cost);
            cmd.Parameters.AddWithValue("brandID", a.brandID);
            cmd.Parameters.AddWithValue("quantity", a.quantity);
            cmd.Parameters.AddWithValue("typeID", a.typeID);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addClothing(Clothing c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Into tbl_clothing (size, color, gender, style, price, cost, brandID, quantity, typeID)"
                + " Values (@size, @color, @gender, @style, @price, @cost, @brandID, @quantity, @typeID)";
            cmd.Parameters.AddWithValue("size", c.size);
            cmd.Parameters.AddWithValue("color", c.color);
            cmd.Parameters.AddWithValue("gender", c.gender);
            cmd.Parameters.AddWithValue("style", c.style);
            cmd.Parameters.AddWithValue("price", c.price);
            cmd.Parameters.AddWithValue("cost", c.cost);
            cmd.Parameters.AddWithValue("brandID", c.brandID);
            cmd.Parameters.AddWithValue("quantity", c.quantity);
            cmd.Parameters.AddWithValue("typeID", c.typeID);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Get item by ID for invoice process **possible deletion
        public List<Clubs> getItemByID(Int32 ItemNumber)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            //cmd.CommandText = "Select * From Inventory Where ItemNumber = @ItemNumber";
            cmd.CommandText = "Select sku, brand, model, clubType, shaft,numberOfClubs, tradeInPrice, premium, wePay, quantity, extendedPrice, retailPrice,  clubSpec, shaftSpec, shaftFlex, dexterity From Item Where SKU = @sku";
            cmd.Parameters.AddWithValue("sku", ItemNumber);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clubs> clubs = new List<Clubs>();

            while (reader.Read())
            {
                Clubs c = new Clubs
                (Convert.ToInt32(reader["sku"]),
                Convert.ToInt32(reader["brandID"]),
                Convert.ToInt32(reader["modelID"]),
                Convert.ToInt32(reader["typeID"]),
                reader["clubType"].ToString(),
                reader["shaft"].ToString(),
                reader["numberOfClubs"].ToString(),
                Convert.ToDouble(reader["premium"]),
                Convert.ToDouble(reader["cost"]),
                Convert.ToDouble(reader["price"]),
                Convert.ToInt32(reader["quantity"]),
                reader["clubSpec"].ToString(),
                reader["shaftSpec"].ToString(),
                reader["shaftFlex"].ToString(),
                reader["dexterity"].ToString(),
                Convert.ToBoolean(reader["used"]),
                reader["comments"].ToString());
                clubs.Add(c);
            }
            conn.Close();
            return clubs;

        }

        //Conversions may be usefull
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

        //Returns single accessory Nathan created
        public Accessories getAccessory(int sku)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select brandID, size, color, price, cost, quantity, typeID From tbl_accessories Where sku = @sku";
            cmd.Parameters.AddWithValue("sku", sku);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //Item List
            Accessories a = new Accessories();

            while (reader.Read())
            {
                a.sku = Convert.ToInt32(reader["sku"]);
                a.brandID = Convert.ToInt32(reader["brandID"]);
                a.size = reader["size"].ToString();
                a.color = reader["color"].ToString();
                a.cost = Convert.ToDouble(reader["cost"]);
                a.price = Convert.ToDouble(reader["price"]);
                a.quantity = Convert.ToInt32(reader["quantity"]);
                a.typeID = Convert.ToInt32(reader["typeID"]);
            }
            con.Close();
            return a;
        }
        //Returns single clothing Nathan created
        public Clothing getClothing(int sku)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select brandID, size, color, gender, style, price, cost, quantity, typeID From tbl_clothing Where sku = @sku";
            cmd.Parameters.AddWithValue("sku", sku);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //Item List
            Clothing c = new Clothing();

            while (reader.Read())
            {
                c.sku = Convert.ToInt32(reader["sku"]);
                c.brandID = Convert.ToInt32(reader["brandID"]);
                c.size = reader["size"].ToString();
                c.color = reader["color"].ToString();
                c.gender = reader["gender"].ToString();
                c.style = reader["style"].ToString();
                c.cost = Convert.ToDouble(reader["cost"]);
                c.price = Convert.ToDouble(reader["price"]);
                c.quantity = Convert.ToInt32(reader["quantity"]);
                c.typeID = Convert.ToInt32(reader["typeID"]);
            }
            con.Close();
            return c;
        }

        // **possible deletion
        public Clubs getItem(int sku)
        {
            //New Command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select sku, brandID, modelID, typeID, clubType, shaft, numberOfClubs, premium, cost, quantity, price, clubSpec,"
                + " shaftSpec, shaftFlex, dexterity From tbl_clubs Where sku = @sku";
            cmd.Parameters.AddWithValue("sku", sku);

            //Open Database Connection
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Clubs clubs = new Clubs();
            while (reader.Read())
            {
                clubs = new Clubs(Convert.ToInt32(reader["sku"]),
                Convert.ToInt32(reader["brandID"]),
                Convert.ToInt32(reader["modelID"]),
                Convert.ToInt32(reader["typeID"]),
                reader["clubType"].ToString(),
                reader["shaft"].ToString(),
                reader["numberOfClubs"].ToString(),
                Convert.ToDouble(reader["premium"]),
                Convert.ToDouble(reader["cost"]),
                Convert.ToDouble(reader["price"]),
                Convert.ToInt32(reader["quantity"]),
                reader["clubSpec"].ToString(),
                reader["shaftSpec"].ToString(),
                reader["shaftFlex"].ToString(),
                reader["dexterity"].ToString(),
                Convert.ToBoolean(reader["used"]),
                reader["comments"].ToString());
            }

            con.Close();
            return clubs;
        }

        //**EVERYTHING BELOW HERE WILL NEED VERIFICATION**//

        //******EXPORT Section*******
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
            ExcelApp.ActiveWorkbook.SaveCopyAs(pathDownload + "\\Inventory-" + DateTime.Now.ToString("d MMM yyyy") + ".xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }


        //Add single item into inventory using IDENTITY_INSERT **possible deletion
        public void addItem(Clubs c)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SET IDENTITY_INSERT tbl_clubs ON; INSERT INTO tbl_clubs(sku, brandID, modelID, clubType, shaft, numberOfClubs,"
                + " premium, cost, price, quantity, clubSpec, shaftSpec, shaftFlex, dexterity, used, typeID, comments) VALUES(@sku,"
                + " @brandID, @modelID, @clubType, @shaft, @numberOfClubs, @premium, @cost, @price, @quantity, @clubSpec, @shaftSpec,"
                + " @shaftFlex, @dexterity, @used, @typeID, @comments); SET IDENTITY_INSERT tbl_clubs OFF;";
            cmd.Parameters.AddWithValue("sku", c.sku);
            cmd.Parameters.AddWithValue("brandID", c.brandID);
            cmd.Parameters.AddWithValue("modelID", c.modelID);
            cmd.Parameters.AddWithValue("clubType", c.clubType);
            cmd.Parameters.AddWithValue("shaft", c.shaft);
            cmd.Parameters.AddWithValue("numberOfClubs", c.numberOfClubs);
            cmd.Parameters.AddWithValue("premium", c.premium);
            cmd.Parameters.AddWithValue("cost", c.cost);
            cmd.Parameters.AddWithValue("price", c.price);
            cmd.Parameters.AddWithValue("quantity", c.quantity);
            cmd.Parameters.AddWithValue("clubSpec", c.clubSpec);
            cmd.Parameters.AddWithValue("shaftSpec", c.shaftSpec);
            cmd.Parameters.AddWithValue("shaftFlex", c.shaftFlex);
            cmd.Parameters.AddWithValue("dexterity", c.dexterity);
            cmd.Parameters.AddWithValue("used", c.used);
            cmd.Parameters.AddWithValue("typeID", c.typeID);
            cmd.Parameters.AddWithValue("comments", c.comments);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Update item in inventory **possible deletion
        public void updateItemInvoice(Clubs c)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE tbl_clubs SET brandID = @brandID, modelID = @modelID, clubType = @clubType, shaft = @shaft,"
                + " numberOfClubs = @numberOfClubs, premium = @premium, cost = @cost, quantity = @quantity, price = @price,"
                + " clubSpec = @clubSpec, shaftSpec = @shaftSpec, shaftFlex = @shaftFlex, used = @used, dexterity = @dexterity,"
                + " comments = @comments WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", c.sku);
            cmd.Parameters.AddWithValue("@brandID", c.brandID);
            cmd.Parameters.AddWithValue("@modelID", c.modelID);
            cmd.Parameters.AddWithValue("@clubType", c.clubType);
            cmd.Parameters.AddWithValue("@shaft", c.shaft);
            cmd.Parameters.AddWithValue("@numberOfClubs", c.numberOfClubs);
            cmd.Parameters.AddWithValue("@premium", c.premium);
            cmd.Parameters.AddWithValue("@cost", c.cost);
            cmd.Parameters.AddWithValue("@quantity", c.quantity);
            cmd.Parameters.AddWithValue("@price", c.price);
            cmd.Parameters.AddWithValue("@clubSpec", c.clubSpec);
            cmd.Parameters.AddWithValue("@shaftSpec", c.shaftSpec);
            cmd.Parameters.AddWithValue("@shaftFlex", c.shaftFlex);
            cmd.Parameters.AddWithValue("@used", c.used);
            cmd.Parameters.AddWithValue("@dexterity", c.dexterity);
            cmd.Parameters.AddWithValue("@comments", c.comments);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Update item in inventory updated Nathan
        public void updateItem(Clubs c)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE tbl_clubs SET brandID = @brandID, modelID = @modelID, clubType = @clubType, shaft = @shaft,"
                + " numberOfClubs = @numberOfClubs, premium = @premium, cost = @cost, price = @price, quantity = @quantity,"
                + " clubSpec = @clubSpec, shaftSpec = @shaftSpec, shaftFlex = @shaftFlex, dexterity = @dexterity,"
                + " comments = @comments WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", c.sku);
            cmd.Parameters.AddWithValue("@brandID", c.brandID);
            cmd.Parameters.AddWithValue("@modelID", c.modelID);
            cmd.Parameters.AddWithValue("@clubType", c.clubType);
            cmd.Parameters.AddWithValue("@shaft", c.shaft);
            cmd.Parameters.AddWithValue("@numberOfClubs", c.numberOfClubs);
            cmd.Parameters.AddWithValue("@premium", c.premium);
            cmd.Parameters.AddWithValue("@cost", c.cost);
            cmd.Parameters.AddWithValue("@quantity", c.quantity);
            cmd.Parameters.AddWithValue("@price", c.price);
            cmd.Parameters.AddWithValue("@comments", c.comments);
            cmd.Parameters.AddWithValue("@clubSpec", c.clubSpec);
            cmd.Parameters.AddWithValue("@shaftSpec", c.shaftSpec);
            cmd.Parameters.AddWithValue("@shaftFlex", c.shaftFlex);
            cmd.Parameters.AddWithValue("@dexterity", c.dexterity);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Update item in inventory created Nathan
        public void updateAccessories(Accessories a)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE tbl_accessories SET size = @size, color = @color, price = @price, cost = @cost, brandID = @brandID,"
                + " quantity = @quantity WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", a.sku);
            cmd.Parameters.AddWithValue("@size", a.size);
            cmd.Parameters.AddWithValue("@color", a.color);
            cmd.Parameters.AddWithValue("@price", a.price);
            cmd.Parameters.AddWithValue("@cost", a.cost);
            cmd.Parameters.AddWithValue("@brandID", a.brandID);
            cmd.Parameters.AddWithValue("@quantity", a.quantity);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Update item in inventory created Nathan
        public void updateClothing(Clothing cl)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE tbl_clothing SET size = @size, color = @color, gender = @gender, style = @style,"
                + " price = @price, cost = @cost, brandID = @brandID, quantity = @quantity, typeID = @typeID WHERE sku = @sku";
            cmd.Parameters.AddWithValue("@sku", cl.sku);
            cmd.Parameters.AddWithValue("@size", cl.size);
            cmd.Parameters.AddWithValue("@color", cl.color);
            cmd.Parameters.AddWithValue("@gender", cl.gender);
            cmd.Parameters.AddWithValue("@style", cl.style);
            cmd.Parameters.AddWithValue("@price", cl.price);
            cmd.Parameters.AddWithValue("@cost", cl.cost);
            cmd.Parameters.AddWithValue("@brandID", cl.brandID);
            cmd.Parameters.AddWithValue("@quantity", cl.quantity);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            //Execute Insert
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //**possible deletion
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


        //Delete item from inventory **possible deletion
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
        //***ALL INVOICE UTILITIES STILL NEED VALIDATION***
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
        //***ALL SALES UTILITIES STILL NEED VALIDATION***
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
        //***ALL TAX UTILITIES STILL NEED VALIDATION***
        public List<Tax> getTaxes(int provStateID)
        {
            //New command
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select tr.taxRate, tbl_taxType.taxName from tbl_taxRate tr"
                            + " inner Join tbl_taxType on tr.taxID = tbl_taxType.taxID"
                            + " inner join (select taxID, max(taxDate) as MTD from tbl_taxRate where provStateID = @provStateID Group By taxID) td"
                            + " on tr.taxID = td.taxID and tr.taxDate = td.MTD where provStateID = @provStateID;";
            cmd.Parameters.AddWithValue("provStateID", provStateID);
            //Declare and open connection
            cmd.Connection = con;
            con.Open();
            List<Tax> tax = new List<Tax>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tax t = new Tax(reader["taxName"].ToString(),
                            Convert.ToDouble(reader["taxRate"]));
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
        //***ALL REPORT UTILITIES STILL NEED VALIDATION***
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