using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Database;
using Repository.Interfaces;
using Repository.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Controllers;

namespace WebApi
{
    public static class AutoFacRegistry
    {
        public static void RegisterDependencies(IContainer Container)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UsersController>().As<IUsersController>();
            //builder.RegisterType(typeof(BaseController<>)).As(typeof(IBaseController<>));
            builder.RegisterType<EmployeesController>().As<IEmployeesController>();

            //builder.RegisterType(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

            builder.RegisterType<DataContext>().As<IDataContext>();

            builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            
            Container = builder.Build();

            DependencyResolver.SetResolver(
                new AutofacDependencyResolver(Container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(Container);
        }
    }
}
