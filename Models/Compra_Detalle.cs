using System;
using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Compra_Detalle
    {
        [Key]
        public int idCompra { get; set; }
        [Key]
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    }
}