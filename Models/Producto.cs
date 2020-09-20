using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CompraDetalle = new HashSet<CompraDetalle>();
        }

        public int IdProducto { get; set; }
        public string DesProducto { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecioProducto { get; set; }
        public int StockAct { get; set; }
        public int StockMin { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<CompraDetalle> CompraDetalle { get; set; }
    }
}
