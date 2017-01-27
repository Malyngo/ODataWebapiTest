using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataWebapiTest.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Customer> Customers { get; set; }
    }
}