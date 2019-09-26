using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Infrastructure;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using NewWebPortal.ApplicationCore.Resources;
using System;
using System.Threading.Tasks;

namespace NewWebPortal.Services
{
    public class SampleService : ISampleService
    {
        private readonly IAsyncRepository<Sample> _respository;

        public SampleService(IAsyncRepository<Sample> respository)
        {
            this._respository = respository;
        }

        public async Task<Response<Sample>> InsertAysnc(Sample sample)
        {
            Response<Sample> respone = new Response<Sample>();
            try
            {
                if (sample == null)
                {
                    respone.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    respone.Message = SampleMessages.NullEntity;
                    return respone;
                }

                respone.Entity =  await _respository.InsertAsync(sample);
                respone.StatusCode = System.Net.HttpStatusCode.Created;
                respone.Message = SampleMessages.InsertSuccess;
            }
            catch (Exception ex)
            {
                respone.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                respone.Message = ex.Message;
            }

            return respone;
        }

        public async Task<Response<Sample>> UpdateAysnc(Sample sample)
        {
            Response<Sample> respone = new Response<Sample>();
            try
            {
                if (sample == null)
                {
                    respone.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    respone.Message = SampleMessages.NullEntity;
                    return respone;
                }

                await _respository.UpdateAsync(sample);
                respone.StatusCode = System.Net.HttpStatusCode.OK;
                respone.Message = SampleMessages.Successfull;
            }
            catch (Exception ex)
            {
                respone.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                respone.Message = ex.Message;
            }

            return respone;
        }

        public async Task<Response<Sample>> DeleteAysnc(int id)
        {
            Response<Sample> respone = new Response<Sample>();
            try
            {
                if (id == 0)
                {
                    respone.StatusCode = System.Net.HttpStatusCode.NotFound;
                    respone.Message = SampleMessages.IdNotExists;
                    return respone;
                }

                await _respository.DeleteAsync(id);
                respone.StatusCode = System.Net.HttpStatusCode.OK;
                respone.Message = SampleMessages.Successfull;
            }
            catch (Exception ex)
            {
                respone.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                respone.Message = ex.Message;
            }

            return respone;
        }

        public async Task<Response<Sample>> SelectAllAsync()
        {
            Response<Sample> respone = new Response<Sample>();
            try
            {
                respone.EntityList = await _respository.SelectAllAsync();
                respone.StatusCode = System.Net.HttpStatusCode.OK;
                respone.Message = SampleMessages.Successfull;
            }
            catch (Exception ex)
            {
                respone.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                respone.Message = ex.Message;
            }

            return respone;
        }

        public async Task<Response<Sample>> GetByIdAsync(int id)
        {
            Response<Sample> respone = new Response<Sample>();
            try
            {
                if (id == 0)
                {
                    respone.StatusCode = System.Net.HttpStatusCode.NotFound;
                    respone.Message = SampleMessages.IdNotExists;
                    return respone;
                }

                respone.Entity = await _respository.GetByIDAsync(id);
                respone.StatusCode = System.Net.HttpStatusCode.OK;
                respone.Message = SampleMessages.InsertSuccess;
            }
            catch (Exception ex)
            {
                respone.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                respone.Message = ex.Message;
            }

            return respone;
        }
    }
}
