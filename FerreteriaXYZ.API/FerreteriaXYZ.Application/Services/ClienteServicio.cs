using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FerreteriaXYZ.Domain.Entities;
using FerreteriaXYZ.Domain.Interfaces.Repositories;
using FerreteriaXYZ.Application.Interfaces;

namespace FerreteriaXYZ.Application.Services
{
    public class ClienteServicio : IServicioBase<Cliente, int>
    {
        private readonly IRepositorioBase<Cliente, int> repoCliente;

        public ClienteServicio(IRepositorioBase<Cliente, int> _repoCliente)
        {
            repoCliente = _repoCliente;
        }

        public Cliente Agregar(Cliente entidad)
        {
            if(entidad == null) 
            {
                throw new ArgumentNullException("Se requiere un cliente");
            }
            var resultCliente = repoCliente.Agregar(entidad);
            repoCliente.GuardarTodosLosCambios();
            return resultCliente;
        }

        public void Editar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Se requiere cliente para editar");

            repoCliente.Editar(entidad);
            repoCliente.GuardarTodosLosCambios();
        }

        public void Eliminar(int entidadId)
        {
            repoCliente.Eliminar(entidadId);
            repoCliente.GuardarTodosLosCambios();
        }

        public List<Cliente> GetAll()
        {
            return repoCliente.GetAll();
        }

        public Cliente SeleccionarID(int entidadId)
        {
            return repoCliente.SeleccionarID(entidadId);
        }
    }
}
