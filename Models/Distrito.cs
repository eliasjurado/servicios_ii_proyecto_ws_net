using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Distrito
    {
        [Key]
        public int idDistrito { get; set; }
        public string nomDistrito { get; set; }
    }
}