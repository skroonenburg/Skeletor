using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Skeletor.Core.Infrastructure
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                    Component.For<NHibernateTransactionInterceptor>().LifestyleSingleton(),
                    
                    AllTypes.FromThisAssembly()
                            .Where(x => x.Name.EndsWith("Service"))
                            .Configure(x => x.LifestyleTransient()
                            ).WithService.FirstInterface(),

                    AllTypes.FromThisAssembly()
                            .Where(x => x.Name.EndsWith("Repository") && !x.Name.Contains("RepositoryBase"))
                            .Configure(x => x.LifestyleTransient()
                            ).WithService.AllInterfaces(),

                    AllTypes.FromThisAssembly()
                            .Where(x => x.Name.EndsWith("Handler"))
                            .Configure(x => x.Interceptors(InterceptorReference.ForType<NHibernateTransactionInterceptor>())
                                             .Last
                                             .LifestyleTransient()
                                             .Proxy.Hook(new ServicesProxyGenerationHook())
                                             .SelectInterceptorsWith(new ServiceInterceptorSelector())
                            ).WithService.FirstInterface()

                );
        }
    }
}