using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasWeb.Domain.Entities;

namespace VentasWeb.Application.Repositories
{
    public interface IClientRepository
    {
        Task<Cliente> GetByIdAsync(Guid Id);
        Task<List<Cliente>> GetAllAsync();
    }
}
