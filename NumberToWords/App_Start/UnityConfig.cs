using NumberToWords.Core.Interfaces;
using NumberToWords.Core.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace NumberToWords
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IManageNumberRepository, ManageNumberRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}