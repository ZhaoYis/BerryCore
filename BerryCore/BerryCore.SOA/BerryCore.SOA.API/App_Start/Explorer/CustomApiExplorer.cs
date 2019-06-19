using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using BerryCore.SOA.API.Attributes;

namespace BerryCore.SOA.API.Explorer
{
    /// <summary>
    /// 自定义API探测器
    /// </summary>
    public class CustomApiExplorer : ApiExplorer
    {
        /// <summary>
        /// 自定义API探测器
        /// </summary>
        /// <param name="configuration"></param>
        public CustomApiExplorer(HttpConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Action探测
        /// </summary>
        /// <param name="actionVariableValue"></param>
        /// <param name="actionDescriptor"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public override bool ShouldExploreAction(string actionVariableValue, HttpActionDescriptor actionDescriptor, IHttpRoute route)
        {
            if (actionDescriptor.ControllerDescriptor.ControllerName == "SwaggerController")
            {
                return false;
            }

            //忽略打了IgnoreAction特性的方法
            var attributes = actionDescriptor.GetCustomAttributes<IgnoreActionAttribute>();
            if (attributes.Count > 0)
            {
                return false;
            }

            return base.ShouldExploreAction(actionVariableValue, actionDescriptor, route);
        }

        /// <summary>
        /// Controller探测
        /// </summary>
        /// <param name="controllerVariableValue"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public override bool ShouldExploreController(string controllerVariableValue, HttpControllerDescriptor controllerDescriptor, IHttpRoute route)
        {
            //controllerVariableValue = controllerVariableValue.Replace(".", "/");

            return base.ShouldExploreController(controllerVariableValue, controllerDescriptor, route);
        }
    }
}