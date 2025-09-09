using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using System.Web;                 // 👈 para HttpContext
using Microsoft.Owin.Security;    // 👈 para IAuthenticationManager

namespace OpenB.Site
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterFactory<IAuthenticationManager>(c =>
                HttpContext.Current.GetOwinContext().Authentication);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


    }

}