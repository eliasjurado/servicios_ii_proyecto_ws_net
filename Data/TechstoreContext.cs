using Microsoft.EntityFrameworkCore;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public class TechstoreContext : DbContext
    {
        public TechstoreContext(DbContextOptions<TechstoreContext> opt) : base(opt)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}