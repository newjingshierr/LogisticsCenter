using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace Logistics
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            RouteTable.Routes.MapHttpRoute(name: "DefaultApiSession",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }).RouteHandler = new SessionControllerRouteHandler();
        }
    }
}
