using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NetSmartzCodingTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            
        }

        ////       For Multilingual
        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //        CultureInfo cultureInfo = null;
        //       // string langName = "fr-FR";
        //        string langName = "En-US";
        //        cultureInfo = new CultureInfo(langName);

        //        //Finally setting culture for each request
        //        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}

    }
}
