using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnQuickSale_Click(object sender, EventArgs e)
        {
            Session["key"] = 1;
            Response.Redirect("SalesCart.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}