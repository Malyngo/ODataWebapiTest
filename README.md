# ODataWebapiTest
Test project for testing duplicate keys

Testing with for example 
http://localhost:60272/odata/Customers?$orderby=Address/Name,WorkAddress/Name

fails with the following result:
```javascript
{"error":{"code":"","message":"The query specified in the URI is not valid. Duplicate property named 'Name' is not supported in '$orderby'.","innererror":{"message":"Duplicate property named 'Name' is not supported in '$orderby'.","type":"Microsoft.OData.ODataException","stacktrace":"   bei System.Web.OData.Query.OrderByQueryOption.ApplyToCore(IQueryable query, ODataQuerySettings querySettings)\r\n   bei System.Web.OData.Query.ODataQueryOptions.ApplyTo(IQueryable query, ODataQuerySettings querySettings)\r\n   bei System.Web.OData.EnableQueryAttribute.ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)\r\n   bei System.Web.OData.EnableQueryAttribute.ExecuteQuery(Object response, HttpRequestMessage request, HttpActionDescriptor actionDescriptor, ODataQueryContext queryContext)\r\n   bei System.Web.OData.EnableQueryAttribute.OnActionExecuted(HttpActionExecutedContext actionExecutedContext)"}}}
```

A query like
http://localhost:60272/odata/Customers?$orderby=Name
works