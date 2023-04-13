using System;
using System.Collections.Generic;

namespace FerreteriaXYZ.Domain.Entities
{

    public partial class DireccionCliente
    {
        public int Codigo { get; set; }

        public string Direccion { get; set; } = null!;

        public string Departamento { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public string Barrio { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}