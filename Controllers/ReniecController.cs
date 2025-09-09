using OpenB.BaseWeb;
using OpenB.Entidad;
using OpenB.Entidad.ws;
using OpenB.Helper;
using OpenB.PIDEServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR,CONSULTA_RENIEC")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]

    public class ReniecController : Controller
    {
        // GET: Reniec
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [LogSEDI(ServicioId = 1)]
        public ActionResult ConsultaServicioDni(Busqueda_Param_Ws m)
        {
            oJson<ERespuestaR> respuesta = new oJson<ERespuestaR>();
            respuesta.flag = false;
            respuesta.mensaje = "Campos obligatorios no ingresados.";

            try
            {
                if (ModelState.IsValid)
                {
                    OpenB.PIDEServices.PIDEServices w = new OpenB.PIDEServices.PIDEServices();
                    var r = w.getDatosReniec(m.param1);

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
}