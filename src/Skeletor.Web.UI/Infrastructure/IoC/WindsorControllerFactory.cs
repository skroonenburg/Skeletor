using System.Web.Mvc;

namespace Skeletor.Web.UI.Infrastructure.IoC
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        public override void ReleaseController(IController controller)
        {
            IoC.Container.Release(controller);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            var instance = IoC.Container.Resolve(controllerType);
            if (instance == null)
                return base.GetControllerInstance(requestContext, controllerType);

            return (IController)instance;
        }
    }
}