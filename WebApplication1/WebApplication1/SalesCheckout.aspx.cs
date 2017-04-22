using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SalesCheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void mopAmericanExpress_Click(object sender, EventArgs e)
        {

        }

        protected void mopCash_Click(object sender, EventArgs e)
        {

        }

        protected void mopDiscover_Click(object sender, EventArgs e)
        {

        }

        protected void mopCheque_Click(object sender, EventArgs e)
        {

        }

        protected void mopMasterCard_Click(object sender, EventArgs e)
        {

        }

        protected void mopDebit_Click(object sender, EventArgs e)
        {

        }

        protected void mopVisa_Click(object sender, EventArgs e)
        {

        }

        protected void mopGiftCard_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesCart.aspx");
        }

        protected void btnLayaway_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalize_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}