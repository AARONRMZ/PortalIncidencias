using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adsincidencias.Controllers
{
    public class RegistrosController : Controller
    {
        //
        // GET: /Registros/

        public ActionResult Index()
        {
            ViewBag.userSession = Session["VarSess"];
            return View();
        }

    }
}
