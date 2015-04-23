using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adsincidencias.entities.Repositories
{
    public class EmpresasRepository
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        public List<Empresa> GetAllEmpresas()
        {
            return db.Empresas.ToList();
        }
    }
}
