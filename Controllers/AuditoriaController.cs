using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class AuditoriaController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}