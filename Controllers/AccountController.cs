using Microsoft.Owin.Security;
using OpenB.BL;
using OpenB.ViewModel;
using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using OpenB.Entidad;
using OpenB.BaseWeb;

namespace OpenB.Site.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class AccountController : Controller
    {
        private readonly IAuthenticationManager _auth;
        private readonly SeguridadBL seguridadAPP;

        public AccountController(IAuthenticationManager auth, SeguridadBL seguridadAPP)
        {
            this._auth = auth;
            this.seguridadAPP = seguridadAPP;
        }

        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View();

            Session.Remove("PreventResend");
            var httpRequestBase = new HttpRequestWrapper(this.HttpContext.ApplicationInstance.Context.Request);
            var Ip = General.GetIPCliente(httpRequestBase);
            var Navegador = General.GetNavegadorCliente(httpRequestBase);
            SeguridadVM seguridadVM = this.seguridadAPP.AutenticarUsuario(1, model.UserName, model.Password, Ip, Navegador);
            if (seguridadVM.UsuarioBE != null)
            {
                this.seguridadAPP.CargarSesion(seguridadVM);
                this.RegistrarCredenciales(seguridadVM);
                //this.seguridadAPP.RegistrarLogin(seguridadVM.UsuarioBE.c_dni, Ip, Navegador, "IN","2");
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    return RedirectToAction("RedirectToDefault");
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario o contraseña inválidos.");
                return View(model);
            }
        }

        private void RegistrarCredenciales(SeguridadVM seguridadVM)
        {
            var name = (string)Session["Login__"];
            var roles = seguridadVM.PerfilBE;
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, name), }, DefaultAuthenticationTypes.ApplicationCookie);
            foreach (var rol in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, rol.perfil));
            }
            this._auth.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, identity);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult RedirectToDefault()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userIdentity = (ClaimsIdentity)User.Identity;
                var claims = userIdentity.Claims;
                var roleClaimType = userIdentity.RoleClaimType;
                var rolesc = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                String[] roles = rolesc.Select(c => c.Value).ToArray();

                if (roles.Count() != 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    LogOff_();
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult LogOff()
        {
            LogOff_();
            return RedirectToAction("Login", "Account");
        }

        public void LogOff_()
        {
            var httpRequestBase = new HttpRequestWrapper(this.HttpContext.ApplicationInstance.Context.Request);
            var Ip = General.GetIPCliente(httpRequestBase);
            var Navegador = General.GetNavegadorCliente(httpRequestBase);
            this.seguridadAPP.RegistrarLogin(User.Identity.Name, Ip, Navegador, "OUT", "2");
            this.seguridadAPP.CerrarSesion();
            this._auth.SignOut();
        }


        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult set_restablecer_clave(ModelSegUsuario m)
        {
            oJson<bool> respuesta = new oJson<bool>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta.data = managementBL.ActualizarClave(m);
                    respuesta.mensaje = "Datos actualizados.";
                    respuesta.flag = true;
                }
                else
                {
                    respuesta.mensaje = "Error en modelo de datos.";
                    respuesta.flag = false;
                    respuesta.errores = ModelState.AllErrors();
                }
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Error consultando datos: " + ex.Message;
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }

    }
}