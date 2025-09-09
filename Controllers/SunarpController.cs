using OpenB.BaseWeb;
using OpenB.Entidad;
using OpenB.Entidad.ws;
using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR,CONSULTA_SUNARP")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class SunarpController : Controller
    {
        // GET: Sunarp
        public ActionResult Index(ESunarpPersona p)
        {

            if (String.IsNullOrEmpty(p.nombre))
            {
                p.nombre= null;
            }
            if (String.IsNullOrEmpty(p.paterno))
            {
                p.paterno= null;
            }
            if (String.IsNullOrEmpty(p.materno))
            {
                p.materno= null;
            }
            return View(p);
        }

        [HttpPost]
        [LogSEDI(ServicioId = 3)]
        public ActionResult ConsultaServicioTPN(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {

                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getTitularidadPersoNatural(m.param1, m.param2, m.param3);
                    r.Result.JsonString = r.Result.JsonString.ToUTF8();
                    respuesta.data = r.Result;
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

        public ActionResult TitularidadPj()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 4)]
        public ActionResult ConsultaServicioTPJ(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {

                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getTitularidadPersoJuridica(m.param1);

                    respuesta.data = r.Result;
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

        public ActionResult RazonSocial()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 5)]
        public ActionResult ConsultaServicioTRS(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    
                    
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getRazonSocial(m.param1);

                    respuesta.data = r.Result;
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
        public ActionResult Oficinas()
        {
            return View();
        }


        [HttpPost]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult ListaOficinas()
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getOficinasSunarp();
                    r.Result.JSonOficinas = r.Result.JSonOficinas.ToUTF8();                                   
                    respuesta.data = r.Result;
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


        public ActionResult Asientos(string numeroPartida, string oficina, string registro)
        {
            ESunarpOfi of = new ESunarpOfi();
            if (!String.IsNullOrEmpty(numeroPartida))
            {
                of.numeroPartida = numeroPartida;
            }
            if (!String.IsNullOrEmpty(oficina))
            {
                of.oficina = oficina;
            }
            if (!String.IsNullOrEmpty(registro))
            {
                of.registro = registro;
            }
            return View(of);
        }

        [HttpPost]
        public ActionResult ListaAsientos(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    //ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getListaAsientos(m.param4, m.param5, m.param3, m.param2);

                    respuesta.data = r.Result;
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
        public ActionResult VerAsientos(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    //ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.ShowAsientos(transaccion, idImg, tipo, nroTotalPag, nroPagRef, pagina);

                    respuesta.data = r.Result;
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

        public ActionResult PlacaVehiculo(string numeroPartida, string oficina, string registro)
        {
            ESunarpOfi of = new ESunarpOfi();
            if (!String.IsNullOrEmpty(numeroPartida))
            {
                of.numeroPartida = numeroPartida;
            }
            if (!String.IsNullOrEmpty(numeroPartida))
            {
                of.registro = numeroPartida;
            }
            if (!String.IsNullOrEmpty(oficina))
            {
                of.oficina = oficina;
            }
            return View(of);
        }

        [HttpPost]
        public ActionResult ListaVehiculoPlaca(Busqueda_Param_Ws m)
        {
            oJson<Object> respuesta = new oJson<Object>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getConsultaVehiculo(m.param4, m.param5, m.param3.ToUpper().Trim());

                    r.Result.JSonVehiculos = r.Result.JSonVehiculos.ToUTF8();
                    respuesta.data = r.Result;
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

    public static class StringExtensions
    {
        public static string ToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }
    }
}