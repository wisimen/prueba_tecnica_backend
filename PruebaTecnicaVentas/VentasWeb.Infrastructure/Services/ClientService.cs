using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasWeb.Application.Features.Clientes.Queries.GetAllClients;
using VentasWeb.Application.Repositories;
using VentasWeb.Domain.Entities;
using VentasWeb.Application.Services;

namespace VentasWeb.Infrastructure.Services
{
    public class ClientService : IClientService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllClientsDTO>> GetAllClients()
        {
            var allClients = await _unitOfWork.Repository<Cliente>().GetAllAsync();
            var mappedClients = Mapper.Instance.Map<List<Cliente>, List<GetAllClientsDTO>>(allClients);
            return mappedClients;
        }
    }
}
