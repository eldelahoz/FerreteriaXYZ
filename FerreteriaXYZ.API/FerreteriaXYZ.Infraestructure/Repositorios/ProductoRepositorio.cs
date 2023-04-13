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
    public class ProductoRepositorio : IRepositorioBase<Producto, int>
    {

        private DbFerreteriaContext _context;

        public ProductoRepositorio(DbFerreteriaContext context)
        {
            _context = context;
        }

        public Producto Agregar(Producto entidad)
        {
            _context.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoId = _context.Productos.Where(c => c.Codigo== entidad.Codigo).FirstOrDefault();
            if(productoId!=null)
            {
                productoId.Nombre = entidad.Nombre is null ? productoId.Nombre : entidad.Nombre;
                productoId.ValorUnitario = entidad.ValorUnitario == 0 ? productoId.ValorUnitario : entidad.ValorUnitario;
                productoId.UnidadCodigo = entidad.UnidadCodigo == 0 ? productoId.UnidadCodigo : entidad.UnidadCodigo;
                productoId.Peso = entidad.Peso == 0 ? productoId.Peso : productoId.Peso;
                productoId.VolumenEmpaque = entidad.VolumenEmpaque == 0 ? productoId.VolumenEmpaque : entidad.VolumenEmpaque;
                productoId.FechaActualizacion = DateTime.Now;
                productoId.IdEstado = entidad.IdEstado == 0 ? productoId.IdEstado : entidad.IdEstado;

                _context.Entry(productoId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(int entidadId)
        {
            var productoId = _context.Productos.Where(c => c.Codigo == entidadId).FirstOrDefault();
            if (productoId != null)
            {
                _context.Productos.Remove(productoId);

            }
        }

        public List<Producto> GetAll()
        {
            return _context.Productos.ToList();
        }

        public void GuardarTodosLosCambios()
        {
            _context.SaveChanges();
        }

        public Producto SeleccionarID(int entidad)
        {
            var productoId = _context.Productos.Where(c => c.Codigo == entidad).FirstOrDefault();
            return productoId;
        }
    }
}
