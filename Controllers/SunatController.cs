using OpenB.BaseWeb;
using OpenB.Entidad;
using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR,CONSULTA_SUNAT")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class SunatController : Controller
    {
        // GET: Sunat
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 2)]
        public ActionResult ConsultaServicioRuc(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r=w.getDatosRUC(m.param1);


                    respuesta.data = r;
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
        public ActionResult ConsultaServicioRucSecundario(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getDatosSecundarios(m.param1);

                    respuesta.data = r;
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
        public ActionResult ConsultaServicioRucDomicilio(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getDomicilioLegal(m.param1);

                    respuesta.data = r;
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
        public ActionResult ConsultaServicioRucRepresentante(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getRepresentanteLegal(m.param1);

                    respuesta.data = r;
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

    }
}
