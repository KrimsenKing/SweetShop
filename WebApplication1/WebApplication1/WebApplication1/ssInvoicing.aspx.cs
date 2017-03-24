using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ssInvoicing : System.Web.UI.Page
    {
        List<Item> invoiveItems;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            txtUPC.Focus();

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExist.Visible = false;
            grdItems.Visible = false;

            if( Session["InvoiveItems"] == null )
                  invoiveItems = new List<Item>();
            else{
                 invoiveItems = (List<Item>) Session["InvoiveItems"] ;
            }

        }

        protected void btnItemLookUp_Click(object sender, EventArgs e)
        {
            
            
            InvoiceUtil iu = new InvoiceUtil();
            List<Item> i = iu.getItemByID(Convert.ToInt64(txtUPC.Text));
            if (i.Count >= 1)
            {
                invoiveItems.Add(i.ElementAt(0));
                Session["InvoiveItems"] = invoiveItems;
                lblExist.Visible = true;
            }
            if (invoiveItems.Count == 0)
            {
                lblExist.Visible = true;
                lblExist.Text = "Item Not Found";
            }
            else
            {

                grdItems.Visible = true;
                lblExist.Visible = false;

                grdItems.DataSource = invoiveItems;
                grdItems.DataBind();
                txtUPC.Text = "";
            }
        }
    }
}