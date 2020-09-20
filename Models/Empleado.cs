using System.ComponentModel.DataAnnotations;

namespace techstore_ws.Models
{
    public class Empleado
    {
        [Key]
        public int idEmpleado{ get; set; }
        public string nomEmpleado { get; set; }
        public string apeEmpleado { get; set; }
        public string dniEmpleado { get; set; }
        public string tlfEmpleado { get; set; }
        public string direcEmpleado { get; set; }
        public int idDistrito{ get; set; }
        public int idCargo{ get; set; }
        public string emailEmpleado { get; set; }
        public string passEmpleado { get; set; }
        public int idTipoUsuario{ get; set; }
    }
}