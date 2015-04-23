using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adsincidencias.entities;

namespace adsincidencias.entities.Repositories
{
    public class UsuariosRepository
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        public List<Usuario> GetAllUsuarios()
        {
            return db.Usuarios.ToList();
        }
    }
}
