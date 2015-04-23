using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adsincidencias.entities.Repositories
{
    public class TecnicosRepository
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        public List<Tecnico> GetAllTecnicos()
        {
            return db.Tecnicos.ToList();
        }
    }
}
