using SweetSpot1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExist.Visible = false;
            grdItems.Visible = false;
             Customer c = (Customer)(Session["Customer"]);
            if( c!=null )
            {
               
                txtFirstName.Text = c.FirstName;
                txtLastName.Text = c.LastName;
                txtEmail.Text = c.Email;
                txtAddress.Text = c.Address;
                txtCity.Text = c.City;
                txtState.Text = c.State;
                txtCountry.Text = c.Country;
                txtZipCode.Text = c.ZipCode;
                txtPhoneNumber.Text = c.PhoneNumber;
                txtEbayUser.Text = c.EbayUserName;
            //and so on....

              
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Customer c = (Customer)(Session["Customer"]);

        }

        protected void btnItemLookUp_Click(object sender, EventArgs e)
        {
            InvoiceUtil iu = new InvoiceUtil();
            List<Item> i = iu.getItemByID(Convert.ToInt64(txtUPC.Text));

            if (i.Count == 0)
            {
                lblExist.Visible = true;
                lblExist.Text = "Item Not Found";
            }
            else
            {

                grdItems.Visible = true;
                lblExist.Visible = false;

                grdItems.DataSource = i;
                grdItems.DataBind();
            }
        }
    }
}