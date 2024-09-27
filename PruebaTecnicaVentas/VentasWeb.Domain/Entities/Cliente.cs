using System;
using System.Collections.Generic;
using VentasWeb.Domain.Common;

namespace VentasWeb.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual IEnumerable<Venta> Compras { get; set; } = default;
    }
}
