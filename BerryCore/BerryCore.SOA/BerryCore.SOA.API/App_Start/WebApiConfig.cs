using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using BerryCore.Extensions;
using BerryCore.SOA.API.Caching;
using BerryCore.SOA.API.Explorer;
using BerryCore.SOA.API.Filters;
using BerryCore.SOA.API.Handlers;
using BerryCore.SOA.API.Selector;
using BerryCore.Utilities;

namespace BerryCore.SOA.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",//{version}
                defaults: new { id = RouteParameter.Optional },
                constraints: new { HttpMethod = new HttpMethodConstraint("GET", "POST", "OPTIONS") }
            );

            //注册自定义Action过滤器
            config.Filters.Add(new ActionParameterFilter());

            //注册自定义API过滤器，接口授权
            //config.Filters.Add(new CheckTokenFilterAttribute());

            //注册自定义API探测器
            config.Services.Replace(typeof(IApiExplorer), new CustomApiExplorer(config));

            //添加版本控制
            config.Services.Replace(typeof(IHttpControllerSelector), new WebApiControllerSelector(config));

            //注册请求频率限制
            RegisterRequestLimitHandlers(config);

            //解决自定义请求头下的跨域问题
            config.MessageHandlers.Add(new CrosHandler());
        }

        /// <summary>
        /// 注册请求频率限制
        /// </summary>
        /// <param name="config"></param>
        private static void RegisterRequestLimitHandlers(HttpConfiguration config)
        {
            //请求频率限制，默认一分钟60次
            int times = ConfigHelper.GetValue("RequestFrequencyLimit").TryToInt32();
            times = times == 0 ? 60 : times;

            config.MessageHandlers.Add(new RequestFrequencyLimitHandlers(
                new InMemoryThrottleStore(),
                no => times,
                TimeSpan.FromMinutes(1)));
        }
    }
}
