using System;
using VentasWeb.Domain.Common.Interfaces;

namespace VentasWeb.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
