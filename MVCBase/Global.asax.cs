using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Helpers;
using System.IdentityModel.Claims;

namespace MVCBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

        }
    }
}
