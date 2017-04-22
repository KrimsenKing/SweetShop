using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Invoice
    {

        public int invoiceId { get; set; }
        public int customerId { get; set; }
        public double gst { get; set; }
        public double pst { get; set; }
        public double paymentTotal { get; set; }
        public double balance { get; set; }
        public double subTotal { get; set; }
        public double total { get; set; }
        public double discount { get; set; }
        public double tradeIn { get; set; }
        public int paymentID { get; set; }
        public int stateprovID { get; set; }
        public bool posted { get; set; }
        public bool inProcess { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime dateModified { get; set; }
        public DateTime saleDate { get; set; }


        public Invoice() { }

        public Invoice(int InvoiceID, int CustomerID, double GST, double PST, double PaymentTotal,
            double SubTotal, double Total, double Discount, double TradeIn, int PaymentID, int StateProveID, bool Posted,
            bool InProcess, DateTime PostedDate, DateTime DateModified, DateTime SaleDate)
        {
            invoiceId = InvoiceID;
            customerId = CustomerID;
            gst = GST;
            pst = PST;
            paymentTotal = PaymentTotal;
            subTotal = SubTotal;
            total = Total;
            discount = Discount;
            tradeIn = TradeIn;
            paymentID = PaymentID;
			stateprovID = StateProveID;
            posted = Posted;
            inProcess = InProcess;
            postedDate = PostedDate;
            dateModified = DateModified;
            saleDate = SaleDate;

        }

        public Invoice(int InvoiceID, int CustomerID, double GST, double PST,  double PaymentTotal,
            double SubTotal, double Total, DateTime SaleDate)
        {
            invoiceId = InvoiceID;
            customerId = CustomerID;
            gst = GST;
            pst = PST;
            paymentTotal = PaymentTotal;
            subTotal = SubTotal;
            total = Total;
            saleDate = SaleDate;
        }

        public Invoice(int InvoiceID, double GST, double PST, 
            double SubTotal, double Total, double PaymentTotal, int StateProvID)
        {
            invoiceId = InvoiceID;
            gst = GST;
            pst = PST;
            paymentTotal = PaymentTotal;
            subTotal = SubTotal;
            total = Total;
            stateprovID = StateProvID;
        }

        public Invoice(int InvoiceID, double GST, double PST, double Total, int PaymentID, DateTime SaleDate)
        {
            invoiceId = InvoiceID;
            gst = GST;
            pst = PST;
            total = Total;
            paymentID = PaymentID;
            saleDate = SaleDate;
        }

        public Invoice(int InvoiceID, double TradeIn, double SubTotal, double GST, double PST, double Total, int PaymentID, DateTime SaleDate)
        {
            invoiceId = InvoiceID;
            tradeIn = TradeIn;
            subTotal = SubTotal;
            gst = GST;
            pst = PST;
            total = Total;
            paymentID = PaymentID;
            saleDate = SaleDate;
        }

        public Invoice(int InvoiceID, double TradeIn, double SubTotal, double GST, double PST, double Total, bool Posted, int PaymentID, DateTime SaleDate)
        {
            invoiceId = InvoiceID;
            tradeIn = TradeIn;
            subTotal = SubTotal;
            gst = GST;
            pst = PST;
            total = Total;
            posted = Posted;
            paymentID = PaymentID;
            saleDate = SaleDate;
        }

        public Invoice( int CustomerID, double GST, double PST, double PaymentTotal, double Balance,
          double SubTotal, double Total, double Discount, double TradeIn, int PaymentID, int StateProveID, bool Posted,
          bool InProcess, DateTime SaleDate)
        {
            
            customerId = CustomerID;
            gst = GST;
            pst = PST;
            paymentTotal = PaymentTotal;
            balance = Balance;
            subTotal = SubTotal;
            total = Total;
            discount = Discount;
            tradeIn = TradeIn;
            paymentID = PaymentID;
            stateprovID = StateProveID;
            posted = Posted;
            inProcess = InProcess;
            saleDate = SaleDate;

        }

        public Invoice(int invoiceID)
        {
            invoiceId = invoiceID;
        }


    }
}
