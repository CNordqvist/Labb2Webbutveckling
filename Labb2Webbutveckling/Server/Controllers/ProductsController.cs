using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories;
using DataAccess.Model;

namespace Labb2Webbutveckling.Server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {

        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel product)
        {
            await _productRepository.AddAsync(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductModel updatedProduct)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            product.ProductNumber = updatedProduct.ProductNumber;
            product.Price = updatedProduct.Price;
            product.ProductCategory = updatedProduct.ProductCategory;
            product.Status = updatedProduct.Status;
            product.ProductName = updatedProduct.ProductName;
            product.ProductDescription = updatedProduct.ProductDescription;

            await _productRepository.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productRepository.RemoveAsync(product);
            return Ok();
        }
    }
}
