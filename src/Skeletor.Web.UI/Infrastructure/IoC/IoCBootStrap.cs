using System.Web;
using AppHarbor.Web.Security;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Skeletor.Web.UI.Infrastructure.IoC
{
    public class IoCBootStrap
    {
        public static IWindsorContainer Configure()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(new IWindsorInstaller[]
                                  {
                                      new ControllersInstaller() 
                                  });

            // AppHarbor.Web.Security
            container.Register(
                Component.For<HttpContextBase>().UsingFactoryMethod(() => new HttpContextWrapper(HttpContext.Current)).LifeStyle.PerWebRequest);
            container.Register(
                Component.For<ICookieAuthenticationConfiguration>().ImplementedBy<ConfigFileAuthenticationConfiguration>().LifeStyle.Transient);
            container.Register(
                Component.For<IAuthenticator>().ImplementedBy<CookieAuthenticator>().LifeStyle.Transient);

            return container;
        }
    }
}