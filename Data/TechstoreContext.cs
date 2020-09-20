using Microsoft.EntityFrameworkCore;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public class TechstoreContext : DbContext
    {
        public TechstoreContext(DbContextOptions<TechstoreContext> opt) : base(opt)
        {

        }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra_Cabecera> Compra_Cabecera { get; set; }
        public DbSet<Compra_Detalle> Compra_Detalle { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        
    }
}