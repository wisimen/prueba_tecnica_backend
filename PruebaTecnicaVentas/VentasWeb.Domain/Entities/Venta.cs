using System;
using System.Collections.Generic;
using VentasWeb.Domain.Common;

namespace VentasWeb.Domain.Entities
{
    public class Venta : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public Guid IdCliente { get; set; }
        public decimal TotalVenta { get; set; }

        public virtual Cliente Cliente { get; set; } = default;
        public virtual IEnumerable<Producto> Productos { get; set; } = default;
    }
}
