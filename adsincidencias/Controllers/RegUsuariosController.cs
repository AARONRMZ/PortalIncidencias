using adsincidencias.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adsincidencias.Controllers
{
    public class RegUsuariosController : Controller
    {
        //
        // GET: /RegUsuarios/

        adsincidencias.entities.adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        public ActionResult RegistrarUsuarios()
        {
            ViewBag.userSession = Session["VarSess"];
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuarios(string passConfInput,string passInput, Usuario usuario)
        {
            usuario.usrContrasena = passInput;

            if (usuario.usrNombre == null || usuario.usrApPaterno == null || usuario.usrApMaterno == null || usuario.usrCorreo == null || usuario.usrContrasena == null)
            {
                return View();
            }
            else if (passInput != passConfInput)
            {
                ViewBag.ErrorPass = "Las contraseñas no coinciden, verifique por favor.";
                return View();
            }else
            {
                try
                {
                    usuario.usrEmpresaID = 1;
                    usuario.usrNombreUsusario = "Carlos001";
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                   ModelState.Clear();
                    ViewBag.Msg = "El usuario se ha registrado correctamente.";
                }catch(Exception e)
                {
                    return View();
                }

            }

            return View();
 
        }

    }
}
