using System;
using SweetShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["key"] != null){
                int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
                SweetShopManager ssm = new SweetShopManager();
                Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                txtCustomer.Text = c.firstName + " " + c.lastName;
            }
            //display system time in Sales Page
            DateTime today = DateTime.Today;
            lblDate.Text = today.ToString("yyyy-MM-dd");
        }

        protected void btnCustomerSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomePage.aspx");
        }

        protected void btnInventorySearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnProceedToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesCheckout.aspx");
        }
    }
}