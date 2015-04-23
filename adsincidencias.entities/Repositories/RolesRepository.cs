using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adsincidencias.entities;

namespace adsincidencias.entities.Repositories
{
    public class RolesRepository
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();
        public List<RolesUsuario> GetAllRoles()
        {
            return db.RolesUsuarios.ToList();
        }
    }
}
