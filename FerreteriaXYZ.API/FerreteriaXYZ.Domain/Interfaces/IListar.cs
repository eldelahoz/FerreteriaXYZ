using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaXYZ.Domain.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> GetAll();
        TEntidad SeleccionarID(TEntidadID entidad);
    }
}
