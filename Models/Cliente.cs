using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CompraCabecera = new HashSet<CompraCabecera>();
        }

        public int IdCliente { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string DniCliente { get; set; }
        public string TlfCliente { get; set; }
        public string DirecCliente { get; set; }
        public int IdDistrito { get; set; }
        public string EmailCliente { get; set; }
        public string PassCliente { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<CompraCabecera> CompraCabecera { get; set; }
    }
}
