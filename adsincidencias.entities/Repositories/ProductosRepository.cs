using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adsincidencias.entities.Repositories
{
    public class ProductosRepository
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        public List<Producto> GetAllProductos()
        {
            return db.Productos.ToList();
        }

        public List<TiposProducto> GetAllTiposProductos()
        {
            return db.TiposProductos.ToList();
        }
    }
}
