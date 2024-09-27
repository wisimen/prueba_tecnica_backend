using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VentasWeb.Application.Features.Clientes.Queries.GetAllClients;
using VentasWeb.Application.Services;

namespace VentasWeb.WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClientService _clientService;
        private readonly IMediator _mediator;
        public ClientesController(IClientService clientService, IMediator mediator)
        {
            _clientService = clientService;
            _mediator = mediator;
        }

        // GET: api/Clientes
        public async Task<List<GetAllClientsDTO>> Get()
        {
            //return await _mediator.Send(new GetAllClientsQuery());
            return await _clientService.GetAllClients();
        }

        // GET: api/Clientes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
