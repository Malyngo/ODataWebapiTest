﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ODataWebapiTest.Models;

namespace ODataWebapiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Address>("Addresses");
            config.EnableQuerySupport(new QueryableAttribute()
            {
                AllowedQueryOptions = System.Web.Http.OData.Query.AllowedQueryOptions.All
            });
            config.OrderBy();

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
