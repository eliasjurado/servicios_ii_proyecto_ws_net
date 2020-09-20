using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nomCliente { get; set; }
        public string apeCliente { get; set; }
        public string dniCliente { get; set; }
        public string tlfCliente { get; set; }
        public string direcCliente { get; set; }
        public int idDistrito { get; set; }
        public string emailCliente { get; set; }
        public string passCliente { get; set; }
        public int idTipoUsuario { get; set; }
    }
}