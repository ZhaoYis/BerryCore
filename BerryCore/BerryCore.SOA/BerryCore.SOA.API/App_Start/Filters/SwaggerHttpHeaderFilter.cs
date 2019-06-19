using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace BerryCore.SOA.API.Filters
{
    public class SwaggerHttpHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            //var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline(); //判断是否添加权限过滤器
            //var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Any(filter => filter is IgnoreTokenAttribute); //判断是否允许匿名方法 
            ////var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            //if (isAuthorized)
            //{
            //}

            //operation.parameters.Add(new Parameter
            //{
            //    name = "Authorization",
            //    @in = "header",
            //    description = "Token",
            //    required = false,
            //    type = "string"
            //});

            //operation.parameters.Add(new Parameter
            //{
            //    name = "Signature",
            //    @in = "header",
            //    description = "签名",
            //    required = false,
            //    type = "string"
            //});

            operation.parameters.Add(new Parameter
            {
                name = "version",
                @in = "header",
                description = "版本号",
                required = false,
                type = "string"
            });
        }
    }
}