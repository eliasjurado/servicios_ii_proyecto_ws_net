using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int IdCargo { get; set; }
        public string NomCargo { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
