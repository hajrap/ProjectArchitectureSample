using NewWebPortal.ApplicationCore.Entities;
using System.Collections.Generic;

namespace NewWebPortal.ApplicationCore.Interfaces.Services
{
    public interface IProductService
    {
        List<Product> Get();
    }
}
