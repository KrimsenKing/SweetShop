using SweetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class InventoryHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInventorySearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {

            }
            else
            {
                SweetShopManager ssm = new SweetShopManager();
                List<Items> i = ssm.GetItemfromSearch(txtSearch.Text, ddlInventoryType.SelectedItem.Text);

                grdInventorySearched.Visible = true;
                grdInventorySearched.DataSource = i;
                grdInventorySearched.DataBind();
            }
        }

        protected void btnAddNewInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryAddNew.aspx");
        }
    }
}