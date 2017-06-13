using SweetShop;
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
        protected void grdEmployeesSearched_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string key = e.CommandArgument.ToString();
            if (e.CommandName == "ViewProfile")
            {
                Session["empKey"] = key;
                Response.Redirect("EmployeeAddNew.aspx");

            }
        }
        protected void btnEmployeeSearch_Click(object sender, EventArgs e)
        {

            EmployeeManager em = new EmployeeManager();
            List<Employee> emp = em.GetEmployeefromSearch(txtSearch.Text);

            grdEmployeesSearched.Visible = true;
            grdEmployeesSearched.DataSource = emp;
            grdEmployeesSearched.DataBind();

        }

        protected void btnLoadItems_Click(object sender, EventArgs e)
        {

        }
        protected void btnLoadEmployee_Click(object sender, EventArgs e)
        {

        }
        protected void btnLoadCustomers_Click(object sender, EventArgs e)
        {

        }
    }
}