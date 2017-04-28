using SweetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class CustomerHomePage : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //int selectedIndex = grdCustomersSearched.SelectedIndex;
            //try
            //{
            //    String key = (((Label)grdCustomersSearched.Rows[selectedIndex].FindControl("key")).Text);
            //}
            //catch (Exception ex) {
            //    String s = ex.ToString();
            //}
        }

        protected void btnCustomerSearch_Click(object sender, EventArgs e)
        {

            SweetShopManager ssm = new SweetShopManager();
            List<Customer> c = ssm.GetCustomerfromSearch(txtSearch.Text);

            if (c.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "*Customer Not Found", true);
            }
            else
            {
                grdCustomersSearched.Visible = true;
               

            }
            grdCustomersSearched.DataSource = c;
            grdCustomersSearched.DataBind();
        }

        protected void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAddNew.aspx");
        }

        //protected void grdCustomersSearched_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int selectedIndex = grdCustomersSearched.SelectedIndex;
        //    // string me = ((Customer)(grdCustomersSearched.SelectedRow.DataItem)).firstName.ToString();
        //    //  string me = ((Customer)(grdCustomersSearched.Rows[selectedIndex].DataItem)).firstName.ToString();
        //    //String key = (((Label)grdCustomersSearched.Rows[selectedIndex].FindControl("key")).Text);
            


        //    //Session["name"] = ((Customer)(grdCustomersSearched.SelectedRow.DataItem)).firstName + " " + ((Customer)(grdCustomersSearched.SelectedRow.DataItem)).lastName;
        //    // Response.Redirect("SalesCart.aspx");
        //}

        protected void grdCustomersSearched_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex == grdCustomersSearched.SelectedIndex)
            //{
            //    Customer c = ((Customer)e.Row.DataItem);
            //}
        }

        protected void grdCustomersSearched_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string key = e.CommandArgument.ToString();
            Session["key"] = key;
            if (e.CommandName == "ViewProfile")
            {
                Response.Redirect("CustomerAddNew.aspx");
                    
            }
            else if(e.CommandName == "StartSale")
            {
                Response.Redirect("SalesCart.aspx");
            }
        }
    }
}