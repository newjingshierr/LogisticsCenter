using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace Logistics
{
    public class SessionRouteHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionRouteHandler(RouteData routeData) : base(routeData)
        {

        }
    }

    public class SessionControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {

            return new SessionRouteHandler(requestContext.RouteData);

        }

    }
}