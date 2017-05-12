using System;
using SweetShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SweetSpotProShop;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesCart : System.Web.UI.Page
    {
        List<Items> invoiceItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["key"] != null)
            {
                int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
                SweetShopManager ssm = new SweetShopManager();
                Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                txtCustomer.Text = c.firstName + " " + c.lastName;
            }
            //display system time in Sales Page
            DateTime today = DateTime.Today;
            lblDate.Text = today.ToString("yyyy-MM-dd");

            if (Session["Items"] == null)
            {
                invoiceItems = new List<Items>();
            }
            else
            {
                invoiceItems = (List<Items>)Session["Items"];
            }

        }

        protected void btnCustomerSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomePage.aspx");
        }

        protected void btnInventorySearch_Click(object sender, EventArgs e)
        {
            ItemDataUtilities idu = new ItemDataUtilities();

            // this looks for the item in the database
            List<Items> i = idu.getItemByID(Convert.ToInt32(txtSearch.Text));


            //check if item exists in database
            if (i.Count != 0)
            {
                //check if this is first entry or not---nivoiceItems.count will be zero for first item
                for (int n = 0; n < invoiceItems.Count; n++)
                {
                    //check if same item is scanned
                    if (invoiceItems.ElementAt(n).sku == i.ElementAt(0).sku)
                    {
                        
                        //increment the quantity by 1
                        invoiceItems.ElementAt(n).quantityInOrder++;

                        i = null;

                    }
                }
            }
            //if adding new item
            if (i != null && i.Count >= 1)
            {
                invoiceItems.Add(i.ElementAt(0));
                Session["Items"] = invoiceItems;

                lblExists.Visible = true;
            }


            // if item is not found
            if (invoiceItems.Count == 0)
            {
                lblExists.Visible = true;
                lblExists.Text = "Item Not Found";
                lblExists.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                grdInventorySearched.Visible = true;
                lblExists.Visible = false;

                //grdItems.DataSource = invoiceItems;
                //grdItems.DataBind();
                //txtItems.Text = "";
            }


            grdInventorySearched.DataSource = invoiceItems;
            grdInventorySearched.DataBind();
            txtSearch.Text = "";

        }

        protected void btnCancelSale_Click(object sender, EventArgs e)
        {
            string conValue = Request.Form["confirm_value"];
            if(conValue == "Yes")
            {
                Session["key"] = null;
                Response.Redirect("HomePage.aspx");
            }
            
        }

        protected void btnProceedToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesCheckout.aspx");
        }


    }
}