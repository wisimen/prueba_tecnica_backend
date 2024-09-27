using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using VentasWeb.Application.Repositories;
using ExpressMapper;
using VentasWeb.Domain.Entities;

namespace VentasWeb.Application.Features.Clientes.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<GetAllClientsDTO>>
    {
    }
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<GetAllClientsDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllClientsDTO>> Handle(GetAllClientsQuery query, CancellationToken cancellationToken)
        {
            var allClients = await _unitOfWork.Repository<Cliente>().GetAllAsync();
            var mappedClients = Mapper.Instance.Map<List <Cliente >, List<GetAllClientsDTO>>(allClients);
            return mappedClients;
        }
    }
}
