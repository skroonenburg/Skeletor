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


            return container;
        }
    }
}