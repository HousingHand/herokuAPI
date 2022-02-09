using HHPassport.BAL.Interface;
using HHPassport.BAL.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HHPassport.ClassicAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IIntegratorBusiness, IntegratorBusiness>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}