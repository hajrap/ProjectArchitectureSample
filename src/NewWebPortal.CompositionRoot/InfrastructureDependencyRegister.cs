using Microsoft.EntityFrameworkCore;
using NewWebPortal.ApplicationCore.Interfaces.Infrastructure;
using NewWebPortal.Infrastructure.Data;
using Ninject.Modules;

namespace NewWebPortal.CompositionRoot
{
    //public class InfrastructureModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        // Register Entity Framework
    //        var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer("Data Source=pci195\\SQL2017;initial catalog=Asg;user id=sa;password=tatva123;Integrated Security=false;MultipleActiveResultSets=True;");

    //        builder.RegisterType<DataContext>()
    //            .WithParameter("options", dbContextOptionsBuilder.Options)
    //            .InstancePerLifetimeScope();

    //        //register all Infrastructure classes dependency
    //        this.Bind<IAsyncRepository>().To<EfRepository>();
    //    }
    //}
}