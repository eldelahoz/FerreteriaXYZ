using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FerreteriaXYZ.Domain.Entities
{

    public partial class Producto
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal ValorUnitario { get; set; }

        public int UnidadCodigo { get; set; }

        public decimal Peso { get; set; }

        public decimal VolumenEmpaque { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public int IdEstado { get; set; }


        public virtual EstadoProducto? IdEstadoNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

        public virtual Unidad? UnidadCodigoNavigation { get; set; }
    }
}