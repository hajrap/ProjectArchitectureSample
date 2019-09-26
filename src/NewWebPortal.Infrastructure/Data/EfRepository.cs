using Microsoft.EntityFrameworkCore;
using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewWebPortal.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dbContext;

        public EfRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<T> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> SelectAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync<T>();
        }

    }
}
