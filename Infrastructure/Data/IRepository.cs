using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Infrastructure.Data
{
    public interface IRepository
    {
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

    }
}


