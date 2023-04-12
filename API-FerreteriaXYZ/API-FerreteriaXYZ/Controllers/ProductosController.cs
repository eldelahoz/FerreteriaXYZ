using API_FerreteriaXYZ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

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
        /// <summary>
        /// Crear productos
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CreateProduct
        ///     {
        ///        "nombre": "Destornillador Estrella",
        ///        "valorUnitario": 15000,
        ///        "unidadCodigo": 2,
        ///        "peso": 23,
        ///        "volumenEmpaque": 23,
        ///        "fechaCreacion": "2023-04-12T17:54:20.028Z",
        ///        "idEstado": 1
        ///     }
        ///
        /// </remarks>
        // POST: api/CreateProduct
        [HttpPost("CreateProduct")]
        public IActionResult CrearProducto([FromBody] Producto objProducto)
        {

            try
            {
                _context.Productos.Add(objProducto);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", resultado = objProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        /// <summary>
        /// Obtener la lista de Productos
        /// </summary>
        /// <returns></returns>
        // GET: api/GetAllProductos
        [HttpGet("GetAllProductos")]
        public IActionResult GetAllProductos()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos = _context.Productos.Include(c => c.IdEstadoNavigation).Include(c=> c.UnidadCodigoNavigation).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", resultado = listProductos }); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, resultado = listProductos }); ;
            }
        }
        // GET: api/GetProduct{id}
        [HttpGet("GetProduct{id}")]
        public IActionResult GetProduct(int id)
        {
            Producto objProducto = new Producto();
            if (_context.Productos == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { resultado = new { } });
            }
            objProducto = _context.Productos.Include(c => c.IdEstadoNavigation).Include(c => c.UnidadCodigoNavigation).Where(p => p.Codigo == id).FirstOrDefault();

            if (objProducto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { resultado = new { } });
            }
            return StatusCode(StatusCodes.Status200OK, new { message = "ok", resultado = objProducto });
            
        }
        
    }
}
