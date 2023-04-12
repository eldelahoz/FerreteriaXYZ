using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class TiposDocumento
{
    public int Codigo { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
