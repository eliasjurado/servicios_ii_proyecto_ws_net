using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string nomCategoria { get; set; }
    }
}