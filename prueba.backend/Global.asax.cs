using prueba.ioc;
using System.Web.Http;
using System.Web.Mvc;

namespace prueba.backend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            IoC.Start();
        }
    }
}
