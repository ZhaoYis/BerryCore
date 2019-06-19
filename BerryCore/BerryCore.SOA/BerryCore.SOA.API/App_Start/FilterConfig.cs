using System.Web.Mvc;
using BerryCore.SOA.API.Attributes;

namespace BerryCore.SOA.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //添加自定义异常处理
            filters.Add(new CustomHandlerErrorAttribute());
        }
    }
}