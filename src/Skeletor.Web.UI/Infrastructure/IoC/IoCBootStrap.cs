using System.Web;
using AppHarbor.Web.Security;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using Skeletor.Core.Infrastructure;

namespace Skeletor.Web.UI.Infrastructure.IoC
{
    public class IoCBootStrap
    {
        public static IWindsorContainer Configure()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(new IWindsorInstaller[]
                                  {
                                      new ControllersInstaller(), new CoreInstaller() 
                                  });

            // AppHarbor.Web.Security
            container.Register(
                Component.For<HttpContextBase>().UsingFactoryMethod(() => new HttpContextWrapper(HttpContext.Current)).LifeStyle.PerWebRequest);
            container.Register(
                Component.For<ICookieAuthenticationConfiguration>().ImplementedBy<ConfigFileAuthenticationConfiguration>().LifeStyle.Transient);
            container.Register(
                Component.For<IAuthenticator>().ImplementedBy<CookieAuthenticator>().LifeStyle.Transient);
            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(x=> MvcApplication.SessionFactory).LifeStyle.Singleton);

            return container;
        }
    }
}