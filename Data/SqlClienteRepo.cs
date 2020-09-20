using System.Collections.Generic;
using System.Linq;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public class SqlClienteRepo : IClienteRepo
    {
        private readonly TechstoreContext _context;

        public SqlClienteRepo(TechstoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Cliente.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Cliente.FirstOrDefault(p => p.IdCliente == id);
        }
    }
}