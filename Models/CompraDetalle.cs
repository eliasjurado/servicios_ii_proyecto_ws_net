using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class CompraDetalle
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual CompraCabecera IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
