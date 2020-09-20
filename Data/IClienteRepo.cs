using System.Collections.Generic;
using techstore_ws.Models;

namespace techstore_ws.Data
{
    public interface IClienteRepo
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
    }
}