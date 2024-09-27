using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasWeb.Domain.Common.Interfaces;

namespace VentasWeb.Application.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
