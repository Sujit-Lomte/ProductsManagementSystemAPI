using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Models.Response;

namespace ProductsManagement.API.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponseModel> GetAllProducts();
        ProductResponseModel GetProductsById(int id);
        ProductResponseModel CreateProduct(CreateProductRequest model);
        Task<ProductResponseModel> UpdateProduct(int id, CreateProductRequest model);
        void DeleteProduct(int id);
    }
}