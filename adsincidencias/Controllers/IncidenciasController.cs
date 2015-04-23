using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adsincidencias.Controllers
{
    public class IncidenciasController : Controller
    {
        // GET: Incidencias
        public ActionResult Incidencias()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }
    }
}