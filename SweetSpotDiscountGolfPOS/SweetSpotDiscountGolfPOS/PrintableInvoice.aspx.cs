using SweetShop;
using SweetSpotDiscountGolfPOS.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class PrintableInvoice : System.Web.UI.Page
    {
        SweetShopManager ssm = new SweetShopManager();
        LocationManager lm = new LocationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
            Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
            lblCustomerName.Text = c.firstName.ToString() + " " + c.lastName.ToString();
            lblStreetAddress.Text = c.primaryAddress.ToString();
            lblPostalAddress.Text = c.city.ToString() + ", " + lm.provinceName(c.province) + " " + c.postalCode.ToString();
            lblPhone.Text = c.primaryPhoneNumber.ToString();
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}