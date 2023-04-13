using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerreteriaXYZ.Domain.Interfaces;

namespace FerreteriaXYZ.Domain.Interfaces.Repositories
{
    public interface IRepositorioBase<TEntidad, TEntidadID> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
    }
}
