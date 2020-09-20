using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Cliente = new HashSet<Cliente>();
            Empleado = new HashSet<Empleado>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomTipoUsuario { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
