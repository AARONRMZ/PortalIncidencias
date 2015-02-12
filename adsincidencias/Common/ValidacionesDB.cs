using adsincidencias.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adsincidencias.Common
{
    public class ValidacionesDB
    {
        adsincidenciasDBModelContainer db = new entities.adsincidenciasDBModelContainer();
        public bool UsuarioValido(string usuario, string password)
        {
            if (db.Usuarios.Any(u => (u.usrCorreo == usuario || u.usrNombreUsusario == usuario) && u.usrContrasena == password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}