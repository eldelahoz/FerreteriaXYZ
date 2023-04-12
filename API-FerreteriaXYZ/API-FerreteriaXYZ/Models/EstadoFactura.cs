using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class EstadoFactura
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;
}
