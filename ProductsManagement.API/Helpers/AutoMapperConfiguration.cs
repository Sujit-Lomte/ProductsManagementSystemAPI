using AutoMapper;
using ProductsManagement.API.DataAccess.Entities;
using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Models.Response;

namespace ProductsManagement.API.Helpers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponseModel>();
        }
    }
}
