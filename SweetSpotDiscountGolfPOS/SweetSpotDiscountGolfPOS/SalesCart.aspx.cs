using System;
using SweetShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SweetSpotProShop;
using System.Data;
using System.Threading.Tasks;

namespace SweetSpotDiscountGolfPOS
{
    public partial class SalesCart : System.Web.UI.Page
    {

        public string skuString;
        public int skuInt;
        SweetShopManager ssm = new SweetShopManager();
        ItemDataUtilities idu = new ItemDataUtilities();
        List<Items> invoiceItems = new List<Items>();
        List<Cart> itemsInCart = new List<Cart>();
        Cart tempItemInCart;
        Object o = new Object();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lblDelete.Visible = false;
                txtSearch.Focus();
                if (Session["key"] != null)
                {
                    int custNum;
                    custNum = (int)(Convert.ToInt32(Session["key"].ToString()));

                    Customer c = ssm.GetCustomerbyCustomerNumber(custNum);
                    txtCustomer.Text = c.firstName + " " + c.lastName;
                }
                //display system time in Sales Page
                DateTime today = DateTime.Today;
                lblDate.Text = today.ToString("yyyy-MM-dd");
                if (Session["ItemsInCart"] != null)
                {
                    grdCartItems.DataSource = Session["ItemsInCart"];
                    grdCartItems.DataBind();
                    lblSubtotalDisplay.Text = "$ " + ssm.returnSubtotalAmount((List<Cart>)Session["ItemsInCart"]).ToString();
                }
            }
            else if (Convert.ToBoolean(Session["UpdateTheCart"]))
            {
                grdCartItems.DataSource = Session["ItemsInCart"];
                grdCartItems.DataBind();
                Session["UpdateTheCart"] = null;
            }
        }
        protected void btnCustomerSelect_Click(object sender, EventArgs e)
        {
            Session["key"] = null;
            Session["shipping"] = null;
            Session["ItemsInCart"] = null;
            Session["CheckOutTotals"] = null;
            Session["MethodsofPayment"] = null;
            Session["Grid"] = null;
            Session["SKU"] = null;
            Session["Items"] = null;
            Response.Redirect("CustomerHomePage.aspx");
        }
        protected void btnInventorySearch_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtSearch.Text, out skuInt))
            {
                skuString = txtSearch.Text;
                invoiceItems = ssm.returnSearchFromAllThreeItemSets(skuString);
            }
            else
            {
                skuString = txtSearch.Text;
                // this looks for the item in the database
                List<Items> i = idu.getItemByID(Convert.ToInt32(skuInt));// txtSearch.Text));

                //if adding new item
                if (i != null && i.Count >= 1)
                {
                    invoiceItems.Add(i.ElementAt(0));
                }
            }

            grdInventorySearched.DataSource = invoiceItems;
            //pass invoice items to Session to delete item from first gridView- grdInventorySerach
            Session["Items"] = invoiceItems;
            grdInventorySearched.DataBind();
            txtSearch.Text = "";

        }
        //Currently used for Removing the row
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int sku = Convert.ToInt32(grdCartItems.Rows[index].Cells[2].Text);
            List<Cart> duplicateCart = (List<Cart>)Session["ItemsInCart"];
            foreach (var cart in duplicateCart)
            {
                if (cart.sku != sku)
                { itemsInCart.Add(cart); }
            }
            grdCartItems.EditIndex = -1;
            Session["ItemsInCart"] = itemsInCart;
            grdCartItems.DataSource = itemsInCart;
            grdCartItems.DataBind();
            lblSubtotalDisplay.Text = "$ " + ssm.returnSubtotalAmount(itemsInCart).ToString();
            //DataTable sc = new DataTable();
            //if (Session["SKU"] != null)
            //{
            //    sc = (DataTable)Session["SKU"];
            //}

            //int index = Convert.ToInt32(e.RowIndex);
            //DataTable dt = (DataTable)Session["Grid"];
            //DataRow rowD = dt.Rows[index];
            //int j;
            //if (Session["count"] != null)
            //{
            //    j = (int)Session["count"];
            //}
            //else
            //{
            //    j = (sc.Rows.Count);
            //}

            //for (int i = (j - 1); i >= 0; i--)
            //{
            //    if (sc.Rows.Count >= 1)
            //    {

            //        if (((sc.Rows[i].ItemArray[0])).Equals(rowD.ItemArray[0]))
            //        {
            //            sc.Rows[i].Delete();
            //            int c = ((j) - 1);
            //            Session["count"] = c;

            //        }
            //    }
            //}
            //dt.Rows[index].Delete();

            //DataTable del = new DataTable();
            //del = createTable();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (i != index)
            //    {
            //        DataRow rowSubtotal = dt.Rows[i];
            //        int subQty = Convert.ToInt32(rowSubtotal.ItemArray[1]);
            //        double subPrice = Convert.ToDouble(rowSubtotal.ItemArray[3]);
            //        subTotal += subQty * subPrice;
            //        del.Rows.Add(rowSubtotal.ItemArray);
            //    }

            //}
            //Session["Grid"] = del;

            //Session["SKU"] = sc;

            //lblTotalVal.Text = subTotal.ToString();
            //grdCartItems.DataSource = dt;
            //grdCartItems.DataBind();

        }
        //Currently used for Editing the row
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            //Label discountAmount = (Label)grdCartItems.Rows[index].Cells[6].FindControl("lblAmountDisplay");
            //string discountOnItem = discountAmount.Text;
            //Label price = (Label)grdCartItems.Rows[index].Cells[5].FindControl("price");
            //string sPrice = price.Text;
            //Label cost = (Label)grdCartItems.Rows[index].Cells[5].FindControl("cost");
            //string sCost = cost.Text;

            //bool radioButtonSelected = false;
            //RadioButton rbOne = (RadioButton)grdCartItems.Rows[index].Cells[6].FindControl("rddiscountdisabled");
            //RadioButton rbTwo = (RadioButton)grdCartItems.Rows[index].Cells[6].FindControl("rdamountdisabled");
            //if (rbOne.Checked)
            //{
            //    radioButtonSelected = true;
            //}
            //else if (rbTwo.Checked)
            //{
            //    radioButtonSelected = false;
            //}

            //string sku = grdCartItems.Rows[index].Cells[2].Text;
            //string quantity = grdCartItems.Rows[index].Cells[3].Text;
            //string desc = grdCartItems.Rows[index].Cells[4].Text;

            //tempItemInCart = new Cart(Convert.ToInt32(sku), desc, Convert.ToInt32(quantity), Convert.ToDouble(sPrice), Convert.ToDouble(sCost),
            //    Convert.ToDouble(discountOnItem), radioButtonSelected);

            //var obj = itemsInCart.FirstOrDefault(x => x.sku == Convert.ToInt32(sku));
            //if (obj != null)
            //{
            //    obj.quantity = tempItemInCart.quantity;
            //    obj.price = tempItemInCart.price;
            //    obj.percentage = tempItemInCart.percentage;
            //    obj.discount = tempItemInCart.discount;
            //}

            grdCartItems.DataSource = (List<Cart>)Session["ItemsInCart"];
            grdCartItems.EditIndex = index;
            grdCartItems.DataBind();
            lblSubtotal.Text = lblSubtotal.Text = "$ " + ssm.returnSubtotalAmount((List<Cart>)Session["ItemsInCart"]).ToString();
        }
        //Currently used for cancelling the edit
        protected void ORowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdCartItems.EditIndex = -1;
            grdCartItems.DataSource = Session["ItemsInCart"];
            grdCartItems.DataBind();
            lblSubtotal.Text = lblSubtotal.Text = lblSubtotal.Text = "$ " + ssm.returnSubtotalAmount((List<Cart>)Session["ItemsInCart"]).ToString();
        }
        //Currently used for updating the row
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            TextBox discountAmount = (TextBox)grdCartItems.Rows[index].Cells[6].FindControl("txtAmnt");
            string discountOnItem = discountAmount.Text;
            Label price = (Label)grdCartItems.Rows[index].Cells[5].FindControl("price");
            string sPrice = price.Text;
            Label cost = (Label)grdCartItems.Rows[index].Cells[5].FindControl("cost");
            string sCost = cost.Text;

            bool radioButtonSelected = false;
            CheckBox chkPerecent = (CheckBox)grdCartItems.Rows[index].Cells[6].FindControl("ckbPercentageEdit");
            //RadioButton rbOne = (RadioButton)grdCartItems.Rows[index].Cells[6].FindControl("rddiscount");
            //RadioButton rbTwo = (RadioButton)grdCartItems.Rows[index].Cells[6].FindControl("rdamount");
            if (chkPerecent.Checked)
            {
                radioButtonSelected = true;
            }
            else
            {
                radioButtonSelected = false;
            }

            bool tradeInItemInCart = ((CheckBox)grdCartItems.Rows[index].Cells[7].FindControl("chkTradeIn")).Checked;
            string sku = grdCartItems.Rows[index].Cells[2].Text;
            string quantity = ((TextBox)grdCartItems.Rows[index].Cells[3].Controls[0]).Text;
            string desc = grdCartItems.Rows[index].Cells[4].Text;

            tempItemInCart = new Cart(Convert.ToInt32(sku), desc, Convert.ToInt32(quantity), Convert.ToDouble(sPrice), Convert.ToDouble(sCost),
                Convert.ToDouble(discountOnItem), radioButtonSelected, tradeInItemInCart);

            //var obj = itemsInCart.FirstOrDefault(x => x.sku == Convert.ToInt32(sku));
            //if (obj != null)
            //{
            //    obj.quantity = tempItemInCart.quantity;
            //    obj.price = tempItemInCart.price;
            //    obj.percentage = tempItemInCart.percentage;
            //    obj.discount = tempItemInCart.discount;
            //}

            List<Cart> duplicateCart = (List<Cart>)Session["ItemsInCart"];
            foreach (var cart in duplicateCart)
            {
                if (cart.sku == tempItemInCart.sku)
                {
                    itemsInCart.Add(tempItemInCart);
                }
                else
                {
                    itemsInCart.Add(cart);
                }
            }
            grdCartItems.EditIndex = -1;
            Session["ItemsInCart"] = itemsInCart;
            grdCartItems.DataSource = itemsInCart;
            grdCartItems.DataBind();
            lblSubtotal.Text = lblSubtotal.Text = lblSubtotal.Text = "$ " + ssm.returnSubtotalAmount(itemsInCart).ToString();
        }
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
        protected void btnProceedToCheckout_Click(object sender, EventArgs e)
        {
            if (!RadioButton2.Checked)
            {
                Session["shipping"] = false;
                Session["ShippingAmount"] = 0;
            }
            else
            {
                Session["shipping"] = true;
                Session["ShippingAmount"] = txtShippingAmount.Text;
            }

            Response.Redirect("SalesCheckout.aspx");
        }
        protected void grdInventorySearched_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            bool bolAdded = false;
            if (Session["ItemsInCart"] != null)
            {
                itemsInCart = (List<Cart>)Session["ItemsInCart"];
            }
            int itemKey = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "AddItem")
            {
                foreach (var cart in itemsInCart)
                {
                    if (cart.sku == itemKey && !bolAdded)
                    {
                        cart.quantity = cart.quantity + 1;
                        bolAdded = true;
                    }
                }

                //int locationID = Convert.ToInt32(lblLocationID.Text);
                int locationID = 0;
                //Finding the min and max range for trade ins
                int[] range = idu.tradeInSkuRange(locationID);

                //If the itemKey is between or equal to the ranges, do trade in
                if (itemKey >= range[0] && itemKey < range[1])
                {
                    //Trade In Sku to add in SK
                    string redirect = "<script>window.open('TradeINEntry.aspx');</script>";
                    Response.Write(redirect);                                                            
                }
                else if (itemsInCart.Count == 0 || !bolAdded)
                {
                    Clubs c = ssm.singleItemLookUp(itemKey);
                    Clothing cl = ssm.getClothing(itemKey);
                    Accessories ac = ssm.getAccessory(itemKey);
                    if (c.sku != 0)
                    {
                        o = c as Object;
                    }
                    else if (cl.sku != 0)
                    {
                        o = cl as Object;
                    }
                    else if (ac.sku != 0)
                    {
                        o = ac as Object;
                    }
                    itemsInCart.Add(idu.addingToCart(o));
                }
            }
            Session["ItemsInCart"] = itemsInCart;
            grdCartItems.DataSource = itemsInCart;
            grdCartItems.DataBind();
            List<Items> nullGrid = new List<Items>();
            nullGrid = null;
            grdInventorySearched.DataSource = nullGrid;
            grdInventorySearched.DataBind();
            lblSubtotalDisplay.Text = "$ " + ssm.returnSubtotalAmount(itemsInCart).ToString("#.00");
        }

        //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (RadioButton2.Checked)
        //    {
        //        txtShippingAmount.Visible = true;
        //        lblShipping.Visible = true;
        //    }else
        //    {
        //        txtShippingAmount.Visible = false;
        //        lblShipping.Visible = false;
        //    }
        //}
    }
}