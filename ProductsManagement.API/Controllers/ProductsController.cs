using ProductsManagement.API.Helpers;
using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.API.DataAccess.Entities;

namespace ProductsManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService userService)
        {
            _productService = userService;
        }


        /// <summary>
        /// Returns all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();

            return CustomResponse.Success(products);
        }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="productRequest">Product Model</param>
        /// <returns>Created Product</returns>
        [HttpPost]
        [Route("createProduct")]
        public IActionResult CreateProduct(CreateProductRequest productRequest)
        {
            var product = _productService.CreateProduct(productRequest);

            return CustomResponse.Success(product);
        }


        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id">Id of the product to update</param>
        /// <param name="updateProductRequest">Product Model</param>
        /// <returns>Updated Product</returns>
        [HttpPut]
        [Route("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateProductRequest updateProductRequest)
        {
            var product = await _productService.UpdateProduct(id, updateProductRequest);

            return CustomResponse.Success(product);
        }

        /// <summary>
        /// Deletes the product
        /// </summary>
        /// <param name="id">Id of the product to delete</param>
        /// <returns>Empty Result</returns>
        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);

            return CustomResponse.Success();
        }
    }
}