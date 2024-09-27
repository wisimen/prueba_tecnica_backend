using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasWeb.Application.Features.Clientes.Queries.GetAllClients;

namespace VentasWeb.Application.Services
{
    public interface IClientService
    {
        Task<List<GetAllClientsDTO>> GetAllClients();
    }
}
