using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class Cliente
{
    public int Codigo { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public int TipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public int CodigoDireccion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual DireccionCliente CodigoDireccionNavigation { get; set; } = null!;

    public virtual TiposDocumento TipoDocumentoNavigation { get; set; } = null!;
}
