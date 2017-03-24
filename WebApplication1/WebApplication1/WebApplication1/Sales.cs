using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Sales
    {
        public int ItemNumber { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int SalesAmount { get; set; }
        public int Taxes { get; set; }
        public DateTime DateOfSale { get; set; }

        public Sales() { }

        public Sales(int itemNumber, int customerId, int employeeId, int salesAmount, int taxes, DateTime dateOfSale)
        {
            ItemNumber = itemNumber;
            CustomerId = customerId;
            EmployeeId = employeeId;
            SalesAmount = salesAmount;
            Taxes = taxes;
            DateOfSale = dateOfSale;
        }
    }
}