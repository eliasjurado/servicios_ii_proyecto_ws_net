using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NomEmpleado { get; set; }
        public string ApeEmpleado { get; set; }
        public string DniEmpleado { get; set; }
        public string TlfEmpleado { get; set; }
        public string DirecEmpleado { get; set; }
        public int IdDistrito { get; set; }
        public int IdCargo { get; set; }
        public string EmailEmpleado { get; set; }
        public string PassEmpleado { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
