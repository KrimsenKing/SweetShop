using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SettingsHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeAddNew.aspx");
        }

        protected void btnEmployeeSearch_Click(object sender, EventArgs e)
        {

        }
    }
}