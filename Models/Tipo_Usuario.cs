using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Tipo_Usuario
    {
        [Key]
        public int idTipoUsuario { get; set; }
        public string nomTipoUsuario { get; set; }
    }
}