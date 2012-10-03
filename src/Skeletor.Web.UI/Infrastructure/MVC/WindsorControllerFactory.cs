﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Skeletor.Web.UI.Infrastructure.MVC
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

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_container.Resolve(controllerType);
        }

    }
}