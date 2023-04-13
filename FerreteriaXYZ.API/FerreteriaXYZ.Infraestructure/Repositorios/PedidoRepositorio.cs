using FerreteriaXYZ.Domain.Entities;
using FerreteriaXYZ.Domain.Interfaces.Repositories;
using FerreteriaXYZ.Infraestructure.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaXYZ.Infraestructure.Repositorios
{
    public class PedidoRepositorio : IRepositorioBase<Pedido, int>
    {
        private DbFerreteriaContext _context;

        public PedidoRepositorio(DbFerreteriaContext context)
        {
            _context = context;
        }

        public Pedido Agregar(Pedido entidad)
        {
            _context.Pedidos.Add(entidad);
            return entidad;
        }

        public void Editar(Pedido entidad)
        {
            var pedidoId = _context.Pedidos.Where(c => c.Factura == entidad.Factura).FirstOrDefault();
            if (pedidoId != null)
            {
                pedidoId.CantidadProducto = entidad.CantidadProducto == 0 ? pedidoId.CantidadProducto : entidad.CantidadProducto;
                _context.Entry(pedidoId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(int entidadId)
        {
            var pedidoId = _context.Pedidos.Where(c => c.Factura == entidadId).FirstOrDefault();
            if (pedidoId != null)
            {
                _context.Clientes.Remove(pedidoId);
            }
        }

        public List<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }

        public void GuardarTodosLosCambios()
        {
            _context.SaveChanges();
        }

        public Pedido SeleccionarID(int entidadId)
        {
            var pedidoId = _context.Clientes.Where(c => c.NumeroDocumento == entidadId.ToString()).FirstOrDefault();
            return pedidoId;
        }
    }
}
