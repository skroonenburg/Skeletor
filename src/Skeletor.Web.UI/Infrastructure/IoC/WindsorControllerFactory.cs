using System.Web.Mvc;
using Castle.Windsor;

namespace Skeletor.Web.UI.Infrastructure.IoC
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            var instance = _container.Resolve(controllerType);
            if (instance == null)
                return base.GetControllerInstance(requestContext, controllerType);

            return (IController)instance;
        }
    }
}