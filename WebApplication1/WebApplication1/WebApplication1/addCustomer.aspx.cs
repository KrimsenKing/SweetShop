using SweetSpot1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class addCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFirstNameCus.Visible = false;
            lblLastNameCus.Visible = false;
            lblEmailCus.Visible = false;
            lblAddressCus.Visible = false;
            lblCityCus.Visible = false;
            lblStateCus.Visible = false;
            lblCountryCus.Visible = false;
            lblZipCodeCus.Visible = false;
            lblPhoneNumCus.Visible = false;
            lblEbayCus.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.Email = txtEmail.Text;
            c.Address = txtAddress.Text;
            c.City = txtCity.Text;
            c.State = txtState.Text;
            c.Country = txtCountry.Text;
            c.ZipCode = txtZipCode.Text;
            c.PhoneNumber = txtPhoneNumber.Text;
            c.EbayUserName = txtEbayUserName.Text;

            CustomerDataUtilities cdu = new CustomerDataUtilities();
            cdu.addCustomer(c);

            lblFirstNameCus.Visible = true;
            lblLastNameCus.Visible = true;
            lblEmailCus.Visible = true;
            lblAddressCus.Visible = true;
            lblCityCus.Visible = true;
            lblStateCus.Visible = true;
            lblCountryCus.Visible = true;
            lblZipCodeCus.Visible = true;
            lblPhoneNumCus.Visible = true;
            lblEbayCus.Visible = true;


            lblCustFirst.Text = txtFirstName.Text;
            lblCustLast.Text = txtLastName.Text;
            lblCustEmail.Text = txtEmail.Text;
            lblCustAddress.Text = txtAddress.Text;
            lblCustCity.Text = txtCity.Text;
            lblCustState.Text = txtState.Text;
            lblCustCountry.Text = txtCountry.Text;
            lblCustZipCode.Text = txtZipCode.Text;
            lblCustPhoneNum.Text = txtPhoneNumber.Text;
            lblCustEbay.Text = txtEbayUserName.Text;


            //CustomerDataUtilities cd = new CustomerDataUtilities();
            ////string customerId = GridView1.SelectedRow.Cells[1].Text;
            ////Added this method to data utilities
            //Customer cus = cd.getCustomerById(Convert.ToInt32(customerId));
            //Session["Customer"] = c;
            //Response.Redirect("WebForm2.aspx");
        }
    }
}