using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class CompraCabecera
    {
        public CompraCabecera()
        {
            CompraDetalle = new HashSet<CompraDetalle>();
        }

        public int IdCompra { get; set; }
        public int IdCliente { get; set; }
        public DateTime FecPedComp { get; set; }
        public DateTime FecEntComp { get; set; }
        public int EstComp { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<CompraDetalle> CompraDetalle { get; set; }
    }
}
