using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class EstadoProducto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
