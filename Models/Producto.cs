using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string desProducto { get; set; }
        public int idCategoria { get; set; }
        public decimal precioProducto { get; set; }
        public int stock_act { get; set; }
        public int stock_min { get; set; }
    }
}