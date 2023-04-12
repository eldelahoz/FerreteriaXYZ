﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_FerreteriaXYZ.Models;

public partial class EstadoProducto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
