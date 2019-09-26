using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;

namespace NewWebPortal.Services
{
    public class ProductService : IProductService
    {
        public List<Product> Get()
        {
            List<Product> lstProducts = new List<Product>()
            {
                new Product(){ Name ="Microscope" , Price="$19.95"},
                new Product(){ Name ="Box Robot" , Price="$28.95"},
                new Product(){ Name ="Scrabble - Word Game" , Price="$34.95"}
            };

            return lstProducts;
        }
    }
}
