using System;
using System.Collections.Generic;

namespace API_FerreteriaXYZ.Models;

public partial class Pedido
{
    public long Codigo { get; set; }

    public long Factura { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string IdCliente { get; set; } = null!;

    public int IdProducto { get; set; }

    public int CantidadProducto { get; set; }

    public decimal ValorTotal { get; set; }
}
