using System.Collections.Generic;
using System.Linq;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public class SqlProductoRepo : IProductoRepo
    {
        private readonly TechstoreContext _context;

        public SqlProductoRepo(TechstoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Producto> GetAllProductos()
        {
            return _context.Producto.ToList();
        }
        public Producto GetProductoById(int id)
        {
            return _context.Producto.FirstOrDefault(p => p.idProducto == id);
        }
    }
}