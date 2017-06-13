using System;
using SweetShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesHomePage : System.Web.UI.Page
    {
        private String connectionString;

        public SalesHomePage()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnQuickSale_Click(object sender, EventArgs e)
        {
            int custId = 1;
            Session["key"] = custId;
            Response.Redirect("SalesCart.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}