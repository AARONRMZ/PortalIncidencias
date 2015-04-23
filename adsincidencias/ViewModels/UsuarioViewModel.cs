using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adsincidencias.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Correo { get; set; }
        public string Contrasena1 { get; set; }
        public string Contrasena2 { get; set; }
        public int Rol { get; set; }
        public int Empresa { get; set; }
        public SelectList Empresas;
        public SelectList Roles;
    }
}