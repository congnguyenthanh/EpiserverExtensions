using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EpiserverExtensions.Example
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);

            routes.MapRoute("AdditionalDiagnosticRoutes",
                            "{lang}/{controller}/{action}",
                            new { action = "Index", param = RouteParameter.Optional });
        }
    }
}