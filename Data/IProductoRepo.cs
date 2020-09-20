using System.Collections.Generic;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public interface IProductoRepo
    {
        IEnumerable<Producto> GetAllProductos();
        Producto GetProductoById(int id);
    }
}