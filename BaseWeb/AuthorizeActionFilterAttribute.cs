using OpenB.ViewModel;
using OpenB.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OpenB.BaseWeb
{
    public class AuthorizeActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                SeguridadVM seguridadVM;
                SeguridadBL seguridadAPP = new SeguridadBL();
                if (controller.User.Identity.IsAuthenticated && HttpContext.Current.Session["Id_Usuario__"] == null)
                {
                    seguridadVM = seguridadAPP.AutenticarUsuario(2, controller.User.Identity.Name, "", "", "");

                    seguridadAPP.CargarSesion(seguridadVM);
                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}