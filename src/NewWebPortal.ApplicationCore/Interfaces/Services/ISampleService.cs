using NewWebPortal.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewWebPortal.ApplicationCore.Interfaces.Services
{
    public interface ISampleService
    {
        Task<Response<Sample>> InsertAysnc(Sample sample);
        Task<Response<Sample>> UpdateAysnc(Sample sample);
        Task<Response<Sample>> DeleteAysnc(int id);
        Task<Response<Sample>> SelectAllAsync();
        Task<Response<Sample>> GetByIdAsync(int id);
    }
}
