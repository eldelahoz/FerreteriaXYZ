using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

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
    [JsonIgnore]
    public virtual EstadoProducto IdEstadoNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    [JsonIgnore]
    public virtual Unidade UnidadCodigoNavigation { get; set; } = null!;
}
