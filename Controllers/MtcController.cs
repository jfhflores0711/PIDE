using OpenB.BaseWeb;
using OpenB.Entidad;
using OpenB.Entidad.ws;
using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR,CONSULTA_MTC")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class MtcController : Controller
    {
        // GET: Mtc
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 6)]
        public ActionResult ConsultaLicenciaConducir(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaS> respuesta = new oJson<ERespuestaS>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getMtcDatosLicencia(m.param1, m.param2);

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

        public ActionResult RecordConductor()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 7)]
        public ActionResult ConsultaRecordConductor(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaS> respuesta = new oJson<ERespuestaS>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getMtcRecordConductor(m.param1, m.param2, m.param3);

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

        public ActionResult DatosPapeletas()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 8)]
        public ActionResult ConsultaDatosPapeletas(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaS> respuesta = new oJson<ERespuestaS>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getMtcDatosPapeletas(m.param1, m.param2);

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

        public ActionResult UltimaLicencia()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 9)]
        public ActionResult ConsultaUltimaLicencia(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaS> respuesta = new oJson<ERespuestaS>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getMtcUltimaLicencia(m.param1, m.param2);

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

        public ActionResult UltimasSanciones()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 10)]
        public ActionResult ConsultaUltimasSanciones(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaS> respuesta = new oJson<ERespuestaS>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getMtcUltimasSanciones(m.param1, m.param2);

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