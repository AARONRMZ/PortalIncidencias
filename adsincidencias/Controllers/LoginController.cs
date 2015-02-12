using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adsincidencias.entities;
using adsincidencias.Common;

namespace adsincidencias.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        
       
        adsincidenciasDBModelContainer db = new entities.adsincidenciasDBModelContainer();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userInput, string passInput)
        {
            ValidacionesDB validar = new ValidacionesDB();

            if(validar.UsuarioValido(userInput,passInput))
            {
                Session["VarSess"] = userInput;
               
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
        }
    }
}
