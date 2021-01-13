using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace StopAndGo.Api.AppStartup
{
    public static class RouteConfigurator
    {
        public static void Configure(IRouteBuilder builder)
        {
            //builder.MapRoute("Api", "api/{*endpoint}", new {controller = "ApiEndpointNotFound", action = "Index"});
            builder.MapRoute("Single Page Application", "{*uri}", new {controller = "SinglePageApplication", action = "Index"});
        }
    }
}
