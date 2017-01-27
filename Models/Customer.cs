using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataWebapiTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int WorkAddressId { get; set; }
        public Address WorkAddress { get; set; }

        public Customer Parent { get; set; }

        public IList<Customer> Children { get; set; }
    }
}