using SweetSpot1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblExist.Text = "";
            GridView1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CustomerDataUtilities cdu = new CustomerDataUtilities();
            List<Customer> c = cdu.getCustomer( Convert.ToInt32(TextBox1.Text));

            if (c.Count == 0)
            {
               
                lblExist.Text = " * Customer not found";
            }
            else
            {
                GridView1.Visible = true;
                lblExist.Text = "";
                GridView1.DataSource = c;
                GridView1.DataBind();
            }
           
            //if (GridView1 == null)
            //{
            //    lblExist.Visible = true;
            //    lblExist.Text = "Customer not found";
                


            //}
            //else
            //{
            //    lblExist.Visible = false;
            //}


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerDataUtilities cdu = new CustomerDataUtilities();
            string customerId = GridView1.SelectedRow.Cells[1].Text;
            //Added this method to data utilities
            Customer c  = cdu.getCustomerById( Convert.ToInt32(customerId));
            Session["Customer"] = c;
            Response.Redirect("WebForm2.aspx");


                
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           

           
        }

    
    }
}