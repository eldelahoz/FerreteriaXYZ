using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class Unidade
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
