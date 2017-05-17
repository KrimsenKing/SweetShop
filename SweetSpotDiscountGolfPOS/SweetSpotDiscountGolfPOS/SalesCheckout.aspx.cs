using SweetShop;
using SweetSpotDiscountGolfPOS.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesCheckout : System.Web.UI.Page
    {
        double carttotal;
        double trade;
        double shipping;
        double subtotal;
        double gst = 0;
        double pst = 0;
        double balancedue;
        List<CheckOut> co;

        protected void Page_Load(object sender, EventArgs e)
        {
            int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
            int empNum = (int)(Convert.ToInt32(Session["employee"].ToString()));
            if (custNum == 1)
            {
                btnLayaway.Visible = false;
            }
            else
            {
                btnLayaway.Visible = true;
            }
            SweetShopManager ssm = new SweetShopManager();
            Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
            EmployeeManager em = new EmployeeManager();
            Employee emp = em.getEmployeeByID(empNum);            
            List<Items> cart = new List<Items>();
            cart = (List<Items>)Session["items"];
            foreach (var item in cart)
            {
                if (item.sku == 0)
                {
                    trade += item.price;
                }
                else
                {
                    carttotal += (item.quantity * item.price);
                }
            }
            lblTotalInCartAmount.Text = "$" + carttotal.ToString();
            lblTradeInsAmount.Text = "$" + trade.ToString();
            subtotal = carttotal - trade;
            lblSubTotalAmount.Text = "$" + subtotal.ToString();

            List<Tax> t = new List<Tax>();
            Boolean bolShip = (Boolean)Session["ship"];
            if (bolShip)
            {
                t = ssm.getTaxes(c.province);
            }
            else
            {
                t = ssm.getTaxes(emp.provState);
            }

            foreach (var T in t)
            {
                switch (T.taxName)
                {
                    case "GST":
                        lblGovernment.Visible = true;
                        gst = (T.taxRate * subtotal);
                        lblGovernmentAmount.Text = "$" + gst.ToString();
                        btnRemoveGov.Visible = true;
                        break;
                    case "PST":
                        lblProvincial.Visible = true;
                        pst = (T.taxRate * subtotal);
                        lblProvincialAmount.Text = "$" + pst.ToString();
                        btnRemoveProv.Visible = true;
                        break;
                    case "HST":
                        lblProvincial.Visible = false;
                        lblGovernment.Text = "HST";
                        gst = (T.taxRate * subtotal);
                        lblGovernmentAmount.Text = "$" + gst.ToString();
                        btnRemoveProv.Visible = false;
                        btnRemoveGov.Text = "HST";
                        break;
                    case "RST":
                        lblProvincial.Visible = true;
                        lblProvincial.Text = "RST";
                        pst = (T.taxRate * subtotal);
                        lblProvincialAmount.Text = "$" + pst.ToString();
                        btnRemoveProv.Visible = true;
                        btnRemoveProv.Text = "RST";
                        break;
                    case "QST":
                        lblProvincial.Visible = true;
                        lblProvincial.Text = "QST";
                        pst = (T.taxRate * subtotal);
                        lblProvincialAmount.Text = "$" + pst.ToString();
                        btnRemoveProv.Visible = true;
                        btnRemoveProv.Text = "QST";
                        break;
                }


            }

            balancedue = gst + pst + subtotal;
            lblBalanceAmount.Text = "$" + balancedue.ToString();
            gvCurrentMOPs.DataSource = co;
            gvCurrentMOPs.DataBind();
        }

        protected void mopAmericanExpress_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(3, dblPaymentAmount);
            co.Add(c);

        }

        protected void mopCash_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(5, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopOnAccount_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(9, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopCheque_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(8, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopMasterCard_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(2, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopDebit_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(7, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopVisa_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(1, dblPaymentAmount);
            co.Add(c);
        }

        protected void mopGiftCard_Click(object sender, EventArgs e)
        {
            double dblPaymentAmount = Convert.ToDouble(Request.Form["retVal"].ToString());
            CheckOut c = new CheckOut(6, dblPaymentAmount);
            co.Add(c);
        }

        protected void btnCancelSale_Click(object sender, EventArgs e)
        {
            string conValue = Request.Form["confirm_value"];
            if (conValue == "Yes")
            {
                Session["key"] = null;
                Response.Redirect("HomePage.aspx");
            }
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