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
    public class ProductoServicio : IServicioBase<Producto, int>
    {

        private readonly IRepositorioBase<Producto, int> repoProducto;

        public ProductoServicio(IRepositorioBase<Producto, int> _repoProducto)
        {
            repoProducto = _repoProducto;
        }
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Se requiere el producto");

            var resultProducto = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Se requiere producto para editar");

            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();
        }

        public void Eliminar(int entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> GetAll()
        {
            return repoProducto.GetAll();
        }

        public Producto SeleccionarID(int entidadId)
        {
            return repoProducto.SeleccionarID(entidadId);
        }
    }
}
