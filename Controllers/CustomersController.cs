using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using ODataWebapiTest.Models;
using Microsoft.Data.OData;
using System.Web.OData.Query;

namespace ODataWebapiTest.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataWebapiTest.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CustomersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings()
        {
            AllowedQueryOptions = AllowedQueryOptions.All,
            AllowedFunctions = AllowedFunctions.All
        };

        IQueryable<Customer> customers;

        public CustomersController()
        {
            var c1 = new Customer { Id = 1, Name = "Facility", AddressId = 1, WorkAddressId = 1, Address = new Address { Id = 1, Name = "b" }, WorkAddress = new Address { Id = 1, Name = "b" } };
            var c2 = new Customer { Id = 2, Name = "Department", AddressId = 1, WorkAddressId = 2, Address = new Address { Id = 1, Name = "b" }, WorkAddress = new Address { Id = 2, Name = "a" } };
            var c3 = new Customer { Id = 3, Name = "Room", AddressId = 1, WorkAddressId = 2, Address = new Address { Id = 1, Name = "b" }, WorkAddress = new Address { Id = 2, Name = "a" } };
            var c4 = new Customer { Id = 4, Name = "Facility", AddressId = 1, WorkAddressId = 2, Address = new Address { Id = 1, Name = "b" }, WorkAddress = new Address { Id = 2, Name = "a" } };
            var c5 = new Customer { Id = 5, Name = "Department", AddressId = 1, WorkAddressId = 2, Address = new Address { Id = 1, Name = "b" }, WorkAddress = new Address { Id = 2, Name = "a" } };

            c3.Parent = c2;
            c2.Parent = c4;
            c5.Parent = c1;

            customers = new List<Customer>()
            {
                c1,
                c2,
                c3,
                c4,
                c5
            }.AsQueryable();
        }

        // GET: odata/Customers
        public IHttpActionResult GetCustomers(ODataQueryOptions<Customer> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IQueryable<Customer>>((IQueryable<Customer>)queryOptions.ApplyTo(customers));

        }

        // GET: odata/Customers(5)
        public IHttpActionResult GetCustomer([FromODataUri] int key, ODataQueryOptions<Customer> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<Customer>(customers.SingleOrDefault(c => c.Id == key));
        }

        
        public SingleResult<Address> GetAddress([FromODataUri] int id)
        {
            return SingleResult.Create(customers.Where(c => c.Id == id).Select(c => c.Address));
        }

        
        public SingleResult<Address> GetWorkAddress([FromODataUri] int id)
        {
            return SingleResult.Create(customers.Where(c => c.Id == id).Select(c => c.WorkAddress));
        }

        // DELETE: odata/Customers(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
