using System;
using System.Collections.Generic;

namespace FerreteriaXYZ.Domain.Entities
{

    public partial class EstadoFactura
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}