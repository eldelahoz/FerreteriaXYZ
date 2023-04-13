using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FerreteriaXYZ.Domain.Entities
{

    public partial class Unidad
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}