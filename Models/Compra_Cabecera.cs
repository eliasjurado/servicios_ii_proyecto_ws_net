using System;
using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Compra_Cabecera
    {
        [Key]
        public int idCompra { get; set; }
        public int idCliente { get; set; }
        public DateTime fec_ped_comp { get; set; }
        public DateTime fec_ent_comp { get; set; }
        public int est_comp { get; set; }
    }
}