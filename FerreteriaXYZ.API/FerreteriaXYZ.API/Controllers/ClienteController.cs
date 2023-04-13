using FerreteriaXYZ.Application.Services;
using FerreteriaXYZ.Domain.Entities;
using FerreteriaXYZ.Infraestructure.Contextos;
using FerreteriaXYZ.Infraestructure.Repositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FerreteriaXYZ.API.Controllers
{
    [Tags("Administrar Clientes")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteServicio CrearServicio()
        {
            DbFerreteriaContext db = new DbFerreteriaContext();
            ClienteRepositorio repo = new ClienteRepositorio(db);
            ClienteServicio servicio = new ClienteServicio(repo);
            return servicio;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.GetAll());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarID(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            var servicio = CrearServicio();
            servicio.Agregar(cliente);
            return Ok("Cliente agregado!");
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            var servicio = CrearServicio();
            cliente.NumeroDocumento = id.ToString();
            servicio.Editar(cliente);
            return Ok("Cliente editado!");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Cliente Eliminado");
        }
    }
}
