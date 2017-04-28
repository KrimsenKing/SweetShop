using System;
using SweetShop;
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
            if (Session["key"] != null)
            {
                int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
                SweetShopManager ssm = new SweetShopManager();
                Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                txtFirstName.Text = c.firstName;
                txtLastName.Text = c.lastName;
                txtPrimaryAddress.Text = c.primaryAddress;
                txtBillingAddress.Text = c.billingAddress;
                txtSecondaryAddress.Text = c.secondaryAddress;
                txtPrimaryPhoneNumber.Text = c.primaryPhoneNumber;
                txtSecondaryPhoneNumber.Text = c.secondaryPhoneNumber;
                txtEmail.Text = c.email;
                txtCity.Text = c.city;
                ddlCountry.SelectedValue = c.country.ToString();
                ddlProvince.SelectedValue = c.province.ToString();
                txtPostalCode.Text = c.postalCode;
            }
            Session["key"] = null;
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomePage.aspx");
        }
    }
}