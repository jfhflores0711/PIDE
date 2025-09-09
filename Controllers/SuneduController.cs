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
    [Authorize(Roles = "ADMINISTRADOR,CONSULTA_SUNEDU")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class SuneduController : Controller
    {
        // GET: Sunedu
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 11)]
        public ActionResult ConsultaServicioGT(Busqueda_Param_Ws m)
        {
            oJson<EResGTSunedu> respuesta = new oJson<EResGTSunedu>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    ServiceSATH.ServiceSathClient w = new ServiceSATH.ServiceSathClient();
                    var r = w.getDatosSunedu(m.param1);


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