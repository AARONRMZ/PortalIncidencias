//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace adsincidencias.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.Usuarios = new HashSet<Usuario>();
        }
    
        public string empNombre { get; set; }
        public int empID { get; set; }
        public string empCalle { get; set; }
        public string empNumInt { get; set; }
        public string empNumExt { get; set; }
        public string empColonia { get; set; }
        public string empPais { get; set; }
        public string empRFC { get; set; }
        public string empCodPos { get; set; }
        public string empTel1 { get; set; }
        public string empTel2 { get; set; }
        public string empExt1 { get; set; }
        public string empExt2 { get; set; }
        public double empLatitud { get; set; }
        public double empLongitud { get; set; }
    
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
