using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Customer
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string primaryAddress { get; set; }
        public string secondaryAddress { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public int province { get; set; }
        public int country { get; set; }
        public string primaryPhoneNumber { get; set; }
        public string secondaryPhoneNumber { get; set; }
        public string email { get; set; }

        public Customer() { }

        public Customer(int CustomerID, string FirstName, string LastName, string pAddress,
            string sAddress, string City, string PostalCode, int Province, int Country,
            string pPhoneNumber, string sPhoneNumber, string Email)
        {
            customerId = CustomerID;
            firstName = FirstName;
            lastName = LastName;
            primaryAddress = pAddress;
            secondaryAddress = sAddress;
            city = City;
            postalCode = PostalCode;
            province = Province;
            country = Country;
            primaryPhoneNumber = pPhoneNumber;
            secondaryPhoneNumber = sPhoneNumber;
            email = Email;
        }

    }
}
