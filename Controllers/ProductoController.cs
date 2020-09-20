using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using techstore_ws.Data;
using techstore_ws.Models;

namespace techstore_ws.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepo _repository;
        public ProductoController(IProductoRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAllProductos()
        {
            var items = _repository.GetAllProductos();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProductoById(int id)
        {
            var item = _repository.GetProductoById(id);
            return item;
        }
    }
}