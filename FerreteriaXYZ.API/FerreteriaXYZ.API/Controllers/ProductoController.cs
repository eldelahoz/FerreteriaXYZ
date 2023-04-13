using Microsoft.AspNetCore.Mvc;
using FerreteriaXYZ.Application.Services;
using FerreteriaXYZ.Infraestructure.Contextos;
using FerreteriaXYZ.Infraestructure.Repositorios;
using FerreteriaXYZ.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FerreteriaXYZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoServicio CrearServicio()
        {
            DbFerreteriaContext db = new DbFerreteriaContext();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.GetAll());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarID(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("Producto agregado!");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.Codigo = id;
            servicio.Editar(producto);
            return Ok("Producto editado!");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Producto Eliminado");
        }
    }
}
