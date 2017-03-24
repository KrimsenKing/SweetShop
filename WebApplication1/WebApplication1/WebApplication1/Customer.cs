using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetSpot1
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EbayUserName { get; set; }

        public Customer() { }

        public Customer(string firstName, string lastName, string email, string address, string city, string state, string country, string zipcode, string phoneNumber, string ebayUserName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            PhoneNumber = phoneNumber;
            EbayUserName = ebayUserName;
        }
        public Customer(int custId, string firstName, string lastName, string email, string address, string city, string state, string country, string zipcode, string phoneNumber, string ebayUserName)
        {
            CustomerId = custId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            PhoneNumber = phoneNumber;
            EbayUserName = ebayUserName;
        }


    }
}
