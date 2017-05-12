using SweetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class CustomerAddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["key"] != null)
            {
                int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
                SweetShopManager ssm = new SweetShopManager();
                Customer c = ssm.GetCustomerbyCustomerNumber(custNum);

                txtFirstName.Text = c.firstName.ToString();
                txtLastName.Text = c.lastName.ToString();
                txtPrimaryAddress.Text = c.primaryAddress.ToString();
                txtBillingAddress.Text = c.billingAddress.ToString();
                txtSecondaryAddress.Text = c.secondaryAddress.ToString();
                txtPrimaryPhoneNumber.Text = c.primaryPhoneNumber.ToString();
                txtSecondaryPhoneNumber.Text = c.secondaryPhoneNumber.ToString();
                txtEmail.Text = c.email.ToString();
                txtCity.Text = c.city.ToString();
                ddlProvince.Text = c.province.ToString();
                ddlCountry.Text = c.country.ToString();
                txtPostalCode.Text = c.postalCode.ToString();
            }

        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomePage.aspx");
        }
    }
}