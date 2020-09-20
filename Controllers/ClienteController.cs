using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using techstore_ws.Data;
using techstore_ws.Models;

namespace techstore_ws.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepo _repository;

        public ClienteController(IClienteRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAllClientes()
        {
            var items = _repository.GetAllClientes();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            var item = _repository.GetClienteById(id);
            return item;
        }

    }
}