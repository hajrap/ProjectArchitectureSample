using System;
using System.Web.Mvc;
using NewWebPortal.CompositionRoot;
using Ninject;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;

namespace NewWebPortal.CustomWidgets
{
    public sealed class NinjectControllerFactory : FrontendControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectControllerFactory"/> class.
        /// </summary>
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel(new DependenciesMappings());
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            var resolvedController = this._ninjectKernel.Get(controllerType);
            IController controller = resolvedController as IController;

            return controller;
        }
    }
}