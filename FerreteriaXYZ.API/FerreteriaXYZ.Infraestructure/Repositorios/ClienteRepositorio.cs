using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FerreteriaXYZ.Domain.Entities;
using FerreteriaXYZ.Domain.Interfaces.Repositories;
using FerreteriaXYZ.Infraestructure.Contextos;

namespace FerreteriaXYZ.Infraestructure.Repositorios
{
    public class ClienteRepositorio : IRepositorioBase<Cliente, int>
    {

        private DbFerreteriaContext _context;

        public ClienteRepositorio(DbFerreteriaContext context)
        {
            _context = context;
        }

        public Cliente Agregar(Cliente entidad)
        {
            _context.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad)
        {
            var clienteId = _context.Clientes.Where(c => c.NumeroDocumento == entidad.NumeroDocumento).FirstOrDefault();
            if (clienteId != null)
            {
                clienteId.PrimerNombre = entidad.PrimerNombre is null ? clienteId.PrimerNombre : entidad.PrimerNombre;
                _context.Entry(clienteId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(int entidadId)
        {
            var clienteId = _context.Clientes.Where(c => c.NumeroDocumento == entidadId.ToString()).FirstOrDefault();
            if(clienteId != null)
            {
                _context.Clientes.Remove(clienteId);
            }
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public void GuardarTodosLosCambios()
        {
            _context.SaveChanges();
        }

        public Cliente SeleccionarID(int entidadId)
        {
            var clienteId = _context.Clientes.Where(c => c.NumeroDocumento == entidadId.ToString()).FirstOrDefault();
            return clienteId;
        }
    }
}
