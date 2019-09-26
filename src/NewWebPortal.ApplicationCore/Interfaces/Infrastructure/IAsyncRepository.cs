using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewWebPortal.ApplicationCore.Interfaces.Infrastructure
{
    public interface IAsyncRepository<T>
        where T : class
    {
        Task<T> GetByIDAsync(int id);

        Task<T> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<List<T>> SelectAllAsync();
    }
}
