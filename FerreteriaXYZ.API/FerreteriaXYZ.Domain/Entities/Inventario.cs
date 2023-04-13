using System;
using System.Collections.Generic;

namespace FerreteriaXYZ.Domain.Entities
{

    public partial class Inventario
    {
        public long Codigo { get; set; }

        public int Pcodigo { get; set; }

        public int IdEstado { get; set; }

        public int CantidadOriginal { get; set; }

        public int CantidadDisponible { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual EstadoProducto IdEstadoNavigation { get; set; } = null!;

        public virtual Producto PcodigoNavigation { get; set; } = null!;
    }
}