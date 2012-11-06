using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Skeletor.Web.UI.Infrastructure.IoC;
using Skeletor.Web.UI.Infrastructure.Nhibernate;
using NHibernate;
using NHibernate.Context;

namespace Skeletor.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static ISessionFactory SessionFactory {get;set;}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SessionFactory = NhibernateBootstrap.Configure();
            IoC.Container = IoCBootStrap.Configure();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
        }


        protected void Application_BeginRequest()
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }


        protected void Application_EndRequest()
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }
    }
}