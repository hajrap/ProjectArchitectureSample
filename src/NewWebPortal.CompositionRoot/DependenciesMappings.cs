using NewWebPortal.ApplicationCore.Interfaces.Services;
using NewWebPortal.Services;
using Ninject.Modules;

namespace NewWebPortal.CompositionRoot
{
    public sealed class DependenciesMappings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            //services mapping
            this.Bind<IProductService>().To<ProductService>();
        }
    }
}