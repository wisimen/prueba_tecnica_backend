using System;
using VentasWeb.Domain.Common;

namespace VentasWeb.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal Existencias { get; set; }
    }
}
