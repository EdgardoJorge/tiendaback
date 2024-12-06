using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaData.Database.Tables;
using TiendaData.Database;

namespace Ejemplo2.Controllers
{

    [ApiController]
    [Route("api/Productos")]
    public class ProductoController : ControllerBase
    {
        private readonly TiendaDbContext _db;

        public ProductoController(TiendaDbContext db)
        {
            _db = db;
        }


        
        [HttpGet]
        [Route("")]
        public IActionResult ListarProductos()
        {
            var productos = _db.productos.ToList();

            return Ok(productos);
        }

        
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerProducto([FromRoute] int id)
        {
            var producto = _db.productos.Find(id);
            if (producto == null)
            {
                return NotFound(); 
            }

            return Ok(producto); 
        }

       
        [HttpPost]
        [Route("")]
        public IActionResult CrearProducto([FromBody] Productos body)
        {
            _db.productos.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }

            return Ok(body);
        }



        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarProducto(
            [FromRoute] int id,
            [FromBody] Productos body)
        {

            var producto = _db.productos.Find(id);
            if (producto == null)
            {
                return NotFound(); 
            }
            producto.Name = body.Name;
            producto.Description = body.Description;
            producto.price = body.price;
            producto.quantity = body.quantity;
            producto.expirationDate = body.expirationDate;
            producto.lote = body.lote;

            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent(); 

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarProducto([FromRoute] int id)
        {
            var Producto = _db.productos.Find(id);
            if (Producto == null)
            {
                return NotFound(); 
            }
         
            _db.productos.Remove(Producto);

            int r = _db.SaveChanges();

            
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("buscar")]
        public IActionResult BusarProductos(
            [FromQuery] string? parametro,
            [FromQuery] int categoria
            )
        {
            parametro = parametro ?? "";

            var productos = _db.productos.Where(
                    p => p.Name.Contains(parametro)
                         //&& (categoria == 0 || p.categoria_id == categoria)
                ).ToList();
            return Ok(productos);
        }
    }

}
