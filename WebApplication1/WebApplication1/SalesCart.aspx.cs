using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SalesCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCustomerSelect_Click(object sender, EventArgs e)
        {

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