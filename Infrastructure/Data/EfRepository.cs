using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfRepository : IRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EfRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public virtual Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _applicationDbContext.Set<T>().AddAsync(entity);
            _applicationDbContext.SaveChangesAsync();

            return entity;
        }

    }
}
