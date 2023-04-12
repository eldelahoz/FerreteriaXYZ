using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FerreteriaXYZ.Models;

namespace API_FerreteriaXYZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbFerreteriaContext _context;

        public ProductosController(DbFerreteriaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public IActionResult Get()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                lista = _context.Productos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            Producto objProducto = _context.Productos.Find(id);
            if (objProducto == null)
            {
                return BadRequest("No se encontro el producto");
            }
            try
            {
                objProducto = _context.Productos.FirstOrDefault(m => m.Codigo == id);
                return StatusCode(StatusCodes.Status200OK, new { objProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });
            }

        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
          if (_context.Productos == null)
          {
              return Problem("Entity set 'DbFerreteriaContext.Productos'  is null.");
          }
            Console.WriteLine(producto);

            return CreatedAtAction("GetProducto", new { id = producto.Codigo }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return (_context.Productos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
