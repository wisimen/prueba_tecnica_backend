using System;

namespace VentasWeb.Application.Features.Clientes.Queries.GetAllClients
{
    public class GetAllClientsDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
