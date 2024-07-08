using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Repositories;
using Unity;
using Unity.Mvc5;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentService, StudentService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
