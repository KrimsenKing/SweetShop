using SweetShop;
using SweetSpotDiscountGolfPOS.ClassLibrary;
using SweetSpotProShop;
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
        SweetShopManager ssm = new SweetShopManager();
        List<Checkout> mopList = new List<Checkout>();
        ItemDataUtilities idu = new ItemDataUtilities();
        CheckoutManager ckm;

        public double dblRemaining;
        public double subtotal;
        public double gst;
        public double pst;
        public double balancedue;
        public double dblAmountPaid;
        public double tradeInCost;
        //Remove Prov or Gov Tax
        bool noGST;
        bool noPST;
        double amountPaid;
        double shippingCost;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<Tax> t = new List<Tax>();
                List<Cart> cart = new List<Cart>();
                CalculationManager cm = new CalculationManager();


                if (Session["MethodsofPayment"] == null)
                {
                    double dblShippingAmount = Convert.ToDouble(Session["ShippingAmount".ToString()]);
                    bool bolShipping = Convert.ToBoolean(Session["shipping"]);
                    if (bolShipping)
                    {
                        int custNum = (int)Convert.ToInt32(Session["key"].ToString());
                        Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                        t = ssm.getTaxes(c.province);
                        lblShipping.Visible = true;
                        lblShippingAmount.Visible = true;
                    }
                    else
                    {
                        //**Will need to be enabled not shipping 
                        //t = ssm.getTaxes(Convert.ToInt(Session["location"].ToString());
                        lblShipping.Visible = false;
                        lblShippingAmount.Visible = false;
                    }
                    ckm = new CheckoutManager(cm.returnTotalAmount(cart), cm.returnDiscount(cart), cm.returnTradeInAmount(cart), dblShippingAmount, true, true, 0, 0, 0, cm.returnSubtotalAmount(cart));
                    foreach (var T in t)
                    {
                        switch (T.taxName)
                        {
                            case "GST":
                                lblGovernment.Visible = true;
                                ckm.dblGst = cm.returnGSTAmount(T.taxRate, ckm.dblSubTotal);
                                lblGovernmentAmount.Text = "$ " + ckm.dblGst.ToString("#0.00");
                                btnRemoveGov.Visible = true;
                                break;
                            case "PST":
                                lblProvincial.Visible = true;
                                pst = Math.Round((T.taxRate * subtotal), 2);
                                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                                btnRemoveProv.Visible = true;
                                break;
                            case "HST":
                                lblProvincial.Visible = false;
                                lblGovernment.Text = "HST";
                                gst = Math.Round((T.taxRate * subtotal), 2);
                                lblGovernmentAmount.Text = "$ " + gst.ToString("#0.00");
                                btnRemoveProv.Visible = false;
                                btnRemoveGov.Text = "HST";
                                break;
                            case "RST":
                                lblProvincial.Visible = true;
                                lblProvincial.Text = "RST";
                                pst = Math.Round((T.taxRate * subtotal), 2);
                                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                                btnRemoveProv.Visible = true;
                                btnRemoveProv.Text = "RST";
                                break;
                            case "QST":
                                lblProvincial.Visible = true;
                                lblProvincial.Text = "QST";
                                pst = Math.Round((T.taxRate * subtotal), 2);
                                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                                btnRemoveProv.Visible = true;
                                btnRemoveProv.Text = "QST";
                                break;
                        }
                    }
                }
                else
                {
                    ckm = (CheckoutManager)Session["CheckOutTotals"];
                    mopList = (List<Checkout>)Session["MethodsofPayment"];
                    foreach (var mop in mopList)
                    {
                        dblAmountPaid += mop.amountPaid;
                    }
                    gvCurrentMOPs.DataSource = mopList;
                    gvCurrentMOPs.DataBind();
                    ckm.dblAmountPaid = dblAmountPaid;
                    ckm.dblRemainingBalance = ckm.dblSubTotal - ckm.dblAmountPaid;

                }
                Session["CheckOutTotals"] = ckm;

                //***Assign each item to its Label.

                //    //Assigning session brought from the cart to variables
                //    int custNum = (int)(Convert.ToInt32(Session["key"].ToString()));
                //    bool shipping = Convert.ToBoolean(Session["shipping"]);
                //    cart = (List<Cart>)Session["ItemsInCart"];
                //    double dblShippingAmount = Convert.ToDouble(Session["ShippingAmount"].ToString());
                //    Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                //    //End of assigning

                //    if (shipping == false)
                //    {
                //        //**Need to change to location for taxes
                //        t = ssm.getTaxes(c.province);
                //        lblShipping.Visible = false;
                //        lblShippingAmount.Visible = false;
                //        //txtShippingAmount.Visible = false;
                //    }
                //    else if (shipping == true)
                //    {
                //        t = ssm.getTaxes(c.province);
                //        lblShipping.Visible = true;
                //        lblShippingAmount.Visible = true;
                //        //txtShippingAmount.Visible = true;
                //    }

                //    lblTotalInCartAmount.Text = "$ " + cm.returnTotalAmount(cart).ToString("#0.00");
                //    lblTotalInDiscountsAmount.Text = "$ " + cm.returnDiscount(cart).ToString("#0.00");
                //    lblTradeInsAmount.Text = "$ " + cm.returnTradeInAmount(cart).ToString("#0.00");
                //    subtotal = cm.returnSubtotalAmount(cart);
                //    lblSubTotalAmount.Text = "$ " + subtotal.ToString("#0.00");                
                //    lblShippingAmount.Text = "$ " + dblShippingAmount.ToString("#0.00");

                //    foreach (var T in t)
                //    {
                //        switch (T.taxName)
                //        {
                //            case "GST":
                //                lblGovernment.Visible = true;
                //                gst = cm.returnGSTAmount(T.taxRate, cart);
                //                lblGovernmentAmount.Text = "$ " + gst.ToString("#0.00");
                //                btnRemoveGov.Visible = true;
                //                break;
                //            case "PST":
                //                lblProvincial.Visible = true;
                //                pst = Math.Round((T.taxRate * subtotal), 2);
                //                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                //                btnRemoveProv.Visible = true;
                //                break;
                //            case "HST":
                //                lblProvincial.Visible = false;
                //                lblGovernment.Text = "HST";
                //                gst = Math.Round((T.taxRate * subtotal), 2);
                //                lblGovernmentAmount.Text = "$ " + gst.ToString("#0.00");
                //                btnRemoveProv.Visible = false;
                //                btnRemoveGov.Text = "HST";
                //                break;
                //            case "RST":
                //                lblProvincial.Visible = true;
                //                lblProvincial.Text = "RST";
                //                pst = Math.Round((T.taxRate * subtotal), 2);
                //                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                //                btnRemoveProv.Visible = true;
                //                btnRemoveProv.Text = "RST";
                //                break;
                //            case "QST":
                //                lblProvincial.Visible = true;
                //                lblProvincial.Text = "QST";
                //                pst = Math.Round((T.taxRate * subtotal), 2);
                //                lblProvincialAmount.Text = "$ " + pst.ToString("#0.00");
                //                btnRemoveProv.Visible = true;
                //                btnRemoveProv.Text = "QST";
                //                break;
                //        }
                //    }
                //    dblAmountPaid = 0;
                //    //Checking if there are MOP's
                //    if (Session["MethodsofPayment"] != null)
                //    {
                //        ck = (List<Checkout>)Session["MethodsofPayment"];
                //        foreach (var mop in ck)
                //        {
                //            dblAmountPaid += mop.amountPaid;
                //        }
                //        gvCurrentMOPs.DataSource = ck;
                //        gvCurrentMOPs.DataBind();
                //    }
                //    //End of checking MOP's

                //    ckm = new CheckoutManager(cm.returnTotalAmount(cart), cm.returnDiscount(cart), cm.returnTradeInAmount(cart), dblShippingAmount, noGST, noPST, gst, pst,(cm.returnSubtotalAmount(cart)-dblAmountPaid));
                //    balancedue = ckm.dblGst + ckm.dblPst + ckm.dblShipping + ckm.dblTotal - (ckm.dblDiscounts + ckm.dblTradeIn);
                //    lblBalanceAmount.Text = "$ " + balancedue.ToString("#0.00");
                //    lblRemainingBalanceDueDisplay.Text = "$ " + balancedue.ToString("#0.00");
                //    Session["CheckOutTotals"] = ckm;
                //}
                //if (txtShippingAmount.Text == null || txtShippingAmount.Text == "")
                //{
                //    txtShippingAmount.Text = "0";
                //}
                //shippingCost = Convert.ToDouble(txtShippingAmount.Text);
                //ckm = (CheckoutManager)Session["CheckOutTotals"];
                //ckm.dblShipping = shippingCost;
                //balancedue = ckm.dblGst + ckm.dblPst + ckm.dblShipping + ckm.dblTotal - (ckm.dblDiscounts + ckm.dblTradeIn);
                //lblBalanceAmount.Text = "$ " + balancedue.ToString("#0.00");
                //Session["CheckOutTotals"] = ckm;
                //if (Session["MethodsofPayment"] == null)
                //{
                //    lblRemainingBalanceDueDisplay.Text = "$ " + balancedue.ToString("#0.00");
                //}
                //else
                //{
                //    ck = (List<Checkout>)Session["MethodsofPayment"];
                //    gvCurrentMOPs.DataSource = ck;
                //    gvCurrentMOPs.DataBind();
                //    foreach (var mop in ck)
                //    {
                //        dblAmountPaid += mop.amountPaid;
                //    }
                //    if (!ckm.blGst)
                //    {
                //        dblRemaining += ckm.dblGst;
                //    }
                //    if (!ckm.blPst)
                //    {
                //        dblRemaining += ckm.dblPst;
                //    }
                //    dblRemaining += ckm.dblTotal + ckm.dblShipping - (ckm.dblDiscounts + ckm.dblTradeIn);
                //    lblRemainingBalanceDueDisplay.Text = "$ " + (dblRemaining - dblAmountPaid).ToString("#0.00");
            }
        }

        //American Express
        protected void mopAmericanExpress_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "American Express", "", -1, -1));
            String methodOfPayment = "American Express";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Cash
        protected void mopCash_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Cash", "", -1, -1));
            String methodOfPayment = "Cash";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Account
        protected void mopOnAccount_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Account", "", -1, -1));
            String methodOfPayment = "Account";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Cheque
        protected void mopCheque_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Cheque", "", -1, -1));
            String methodOfPayment = "Cheque";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //MasterCard
        protected void mopMasterCard_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Master Card", "", -1, -1));
            String methodOfPayment = "MasterCard";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Debit
        protected void mopDebit_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Debit", "", -1, -1));
            String methodOfPayment = "Debit";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Visa
        protected void mopVisa_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Visa", "", -1, -1));
            String methodOfPayment = "Visa";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }
        //Gift Card
        protected void mopGiftCard_Click(object sender, EventArgs e)
        {
            amountPaid = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Amount Paid", "Gift Card", "", -1, -1));
            String methodOfPayment = "Gift Card";

            populateGridviewMOP(amountPaid, methodOfPayment);
        }

        //Populating gridview with MOPs
        protected void populateGridviewMOP(double amountPaid, string methodOfPayment)
        {

            Checkout tempCK = new Checkout(methodOfPayment, amountPaid);
            if (Session["MethodsofPayment"] != null)
            {
                mopList = (List<Checkout>)Session["MethodsofPayment"];
            }
            //ck = ckm.methodsOfPayment(methodOfPayment, amountPaid, ck);
            mopList.Add(tempCK);
            gvCurrentMOPs.DataSource = mopList;
            foreach (var mop in mopList)
            {
                dblAmountPaid += mop.amountPaid;
            }
            gvCurrentMOPs.DataBind();
            foreach (GridViewRow row in gvCurrentMOPs.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            Session["MethodsofPayment"] = mopList;
            ckm = (CheckoutManager)Session["CheckOutTotals"];
            if (!ckm.blGst)
            {
                dblRemaining += ckm.dblGst;
            }
            if (!ckm.blPst)
            {
                dblRemaining += ckm.dblPst;
            }
            dblRemaining += ckm.dblTotal + ckm.dblShipping - (ckm.dblDiscounts + ckm.dblTradeIn);
            lblRemainingBalanceDueDisplay.Text = "$ " + (dblRemaining - dblAmountPaid).ToString("#0.00");
        }

        //For some reason, its only subtracting one, and not the other
        protected void btnRemoveGovTax(object sender, EventArgs e)
        {
            ckm = (CheckoutManager)Session["CheckOutTotals"];
            noGST = ckm.blGst;
            balancedue = ckm.dblTotal + ckm.dblShipping + ckm.dblGst + ckm.dblPst - (ckm.dblDiscounts + ckm.dblTradeIn);
            if (noGST)
            {
                //noGST is now false so add back in
                noGST = false;
                ckm.blGst = noGST;
                if (ckm.blPst)
                {
                    balancedue -= ckm.dblPst;
                    lblProvincialAmount.Text = "$ 0.00";
                }
                lblGovernmentAmount.Text = "$ " + ckm.dblGst.ToString("#0.00");
                btnRemoveGov.Text = "Remove GST";
            }
            else
            {
                //noGST is now True so remove
                noGST = true;
                ckm.blGst = noGST;
                if (!ckm.blPst)
                {
                    balancedue -= ckm.dblGst;
                    lblProvincialAmount.Text = "$ " + ckm.dblPst.ToString("#0.00");
                }
                else if (ckm.blPst)
                {
                    balancedue -= ckm.dblGst + ckm.dblPst;
                    lblProvincialAmount.Text = "$ 0.00";
                }
                lblGovernmentAmount.Text = "$ 0.00";
                btnRemoveGov.Text = "Add GST";
            }
            lblBalanceAmount.Text = "$ " + balancedue.ToString("#0.00");
            Session["CheckOutTotals"] = ckm;
            if (Session["MethodsofPayment"] == null)
            {
                lblRemainingBalanceDueDisplay.Text = "$ " + balancedue.ToString("#0.00");
            }
            else
            {
                lblRemainingBalanceDueDisplay.Text = "$ " + (balancedue - dblAmountPaid).ToString("#0.00");
            }
        }
        protected void btnRemoveProvTax(object sender, EventArgs e)
        {
            ckm = (CheckoutManager)Session["CheckOutTotals"];
            noPST = ckm.blPst;
            balancedue = ckm.dblTotal + ckm.dblShipping + ckm.dblGst + ckm.dblPst - (ckm.dblDiscounts + ckm.dblTradeIn);
            if (noPST)
            {
                //noPST is now false so add back in
                noPST = false;
                ckm.blPst = noPST;
                if (ckm.blGst)
                {
                    balancedue -= ckm.dblGst;
                    lblGovernmentAmount.Text = "$ 0.00";
                }
                btnRemoveProv.Text = "Remove PST";
                lblProvincialAmount.Text = "$ " + ckm.dblPst.ToString("#0.00");
            }
            else
            {
                //noPST is now True so remove
                noPST = true;
                ckm.blPst = noPST;
                if (!ckm.blGst)
                {
                    balancedue -= ckm.dblPst;
                    lblGovernmentAmount.Text = "$ " + ckm.dblGst.ToString("#0.00");
                }
                else if (ckm.blGst)
                {
                    balancedue -= ckm.dblGst + ckm.dblPst;
                    lblGovernmentAmount.Text = "$ 0.00";
                }
                lblProvincialAmount.Text = "$ 0.00";
                btnRemoveProv.Text = "Add PST";
            }
            lblBalanceAmount.Text = "$ " + balancedue.ToString("#0.00");
            Session["CheckOutTotals"] = ckm;
            if (Session["MethodsofPayment"] == null)
            {
                lblRemainingBalanceDueDisplay.Text = "$ " + balancedue.ToString("#0.00");
            }
            else
            {
                lblRemainingBalanceDueDisplay.Text = "$ " + (balancedue - dblAmountPaid).ToString("#0.00");
            }
        }
        //Other functionality
        protected void btnCancelSale_Click(object sender, EventArgs e)
        {
            Session["key"] = null;
            Session["shipping"] = null;
            Session["ItemsInCart"] = null;
            Session["CheckOutTotals"] = null;
            Session["MethodsofPayment"] = null;
            Session["Grid"] = null;
            Session["SKU"] = null;
            Session["Items"] = null;
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

            ssm.transferTradeInStart((List<Cart>)Session["ItemsInCart"]);

            Session["key"] = null;
            Session["shipping"] = null;
            Session["ItemsInCart"] = null;
            Session["CheckOutTotals"] = null;
            Session["MethodsofPayment"] = null;
            Session["Grid"] = null;
            Session["SKU"] = null;
            Session["Items"] = null;
            Response.Redirect("PrintableInvoice.aspx");
        }
    }
}