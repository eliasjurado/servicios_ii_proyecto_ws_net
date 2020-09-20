using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Cargo
    {
        [Key]
        public int idCargo { get; set; }
        public string nomCargo { get; set; }
    }
}