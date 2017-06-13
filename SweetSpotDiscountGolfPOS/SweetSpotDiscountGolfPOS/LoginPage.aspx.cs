using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SweetSpotDiscountGolfPOS
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SweetSpotDevConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT empID, password FROM tbl_userInfo WHERE password = @password", con);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = txtPassword.Text;
                Response.Redirect("HomePage.aspx");
                Session.RemoveAll();
            }
            else
            {
                lblError.Text = "Your password is incorrect";
                lblError.ForeColor = System.Drawing.Color.Red;

            }
        }

    }
}