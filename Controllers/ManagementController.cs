using OpenB.BaseWeb;
using OpenB.BL;
using OpenB.Entidad;
using OpenB.Helper;
using OpenB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class ManagementController : Controller
    {
        #region rol
        public ActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar_roles(Busqueda_Param m)
        {
            oJson<VMRoles> respuesta = new oJson<VMRoles>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta.data = managementBL.getListaRoles(m);
                    respuesta.mensaje = "Datos encontrados.";
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

        [HttpPost]
        public ActionResult set_roles(ModelUsuarioRole m)
        {
            oJson<int> respuesta = new oJson<int>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta.data = managementBL.setRol(m);
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



        #endregion

        #region usuario
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar_usuarios(Busqueda_Param_Usuario m)
        {
            oJson<VMUsuarios> respuesta = new oJson<VMUsuarios>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta.data = managementBL.getListaUsuarios(m);
                    respuesta.mensaje = "Datos encontrados.";
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

        [HttpPost]
        public ActionResult Actualizar_usuario(int id)
        {
            oJson<ModelUsuario> respuesta = new oJson<ModelUsuario>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    UsuariomBE m = new UsuariomBE();
                    m.n_id_usuario = id;
                    if (managementBL.updUsuario(m) == 1)
                    {
                        respuesta.mensaje = "Registro anulado.";
                        respuesta.flag = true;
                    }
                    else
                    {
                        respuesta.mensaje = "Error registrando datos.";
                        respuesta.flag = false;
                    }
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
                respuesta.mensaje = "Error registrando datos: " + ex.Message;
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Actualizar_clave(int n_id_usuario, string c_clave)
        {
            oJson<ModelUsuario> respuesta = new oJson<ModelUsuario>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            if(String.IsNullOrEmpty(c_clave))
            {
                respuesta.mensaje = "Escriba clave de 8 dígitos e intente nuevamente.";
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            if (c_clave.Trim().Length < 8 )
            {
                respuesta.mensaje = "Escriba clave de 8 dígitos e intente nuevamente.";
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (managementBL.updUsuarioPass(n_id_usuario, c_clave, 0) == 1)
                    {
                        respuesta.mensaje = "Registro actualizado.";
                        respuesta.flag = true;
                    }
                    else
                    {
                        respuesta.mensaje = "Error registrando datos.";
                        respuesta.flag = false;
                    }
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
                respuesta.mensaje = "Error registrando datos: " + ex.Message;
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Edicion_cliente(ModelUsuario m)
        {
            oJson<ModelUsuario> respuesta = new oJson<ModelUsuario>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    if (managementBL.setUsuario(m) == 1)
                    {
                        respuesta.mensaje = "Datos registrados.";
                        respuesta.flag = true;
                    }
                    else
                    {
                        respuesta.mensaje = "Error registrando datos.";
                        respuesta.flag = false;
                    }
                }
                else
                {
                    respuesta.mensaje = "Error en modelo de datos.";
                    respuesta.flag = false;
                    respuesta.errores = ModelState.AllErrors();
                }
                respuesta.data = m;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Error consultando datos: " + ex.Message;
                respuesta.flag = false;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Listar_roles_usuario(int id)
        {
            oJson<List<UsuarioRoles>> respuesta = new oJson<List<UsuarioRoles>>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta.data = managementBL.getUsuarioRol(id);
                    respuesta.mensaje = "Datos encontrados.";
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


        #endregion
    }
}