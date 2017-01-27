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
    builder.EntitySet<Address>("Addresses");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AddressesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();


        IQueryable<Customer> customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "1", Address = new Address { Id=1, Name="1"}, WorkAddress = new Address { Id=1, Name="1"}},
                new Customer { Id = 2, Name = "2", Address = new Address { Id=1, Name="1"}, WorkAddress = new Address { Id=2, Name="2"}},
            }.AsQueryable();

        // GET: odata/Addresses
        public IHttpActionResult GetAddresses(ODataQueryOptions<Address> queryOptions)
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

            return Ok<IEnumerable<Address>>(customers.Select(c => c.WorkAddress));
        }

        // GET: odata/Addresses(5)
        public IHttpActionResult GetAddress([FromODataUri] int key, ODataQueryOptions<Address> queryOptions)
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

            return Ok<Address>(customers.Select(c => c.Address).Where(a => a.Id == key).Take(1).SingleOrDefault());
        }

        // DELETE: odata/Addresses(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
