using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Skeletor.Web.UI.Infrastructure.IoC;
using Skeletor.Web.UI.Infrastructure.Nhibernate;
using NHibernate;

namespace Skeletor.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private ISessionFactory sessionFactory;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            sessionFactory = NhibernateBootstrap.Configure();
            IoC.Container = IoCBootStrap.Configure();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
        }
    }
}