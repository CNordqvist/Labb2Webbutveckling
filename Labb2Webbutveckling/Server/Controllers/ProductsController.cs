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
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
            
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel product)
        {
            _productRepository.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductModel updatedProduct)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();

            product.ProductNumber = updatedProduct.ProductNumber;
            product.Price = updatedProduct.Price;
            product.ProductCategory = updatedProduct.ProductCategory;
            product.Status = updatedProduct.Status;
            product.ProductName = updatedProduct.ProductName;
            product.ProductDescription = updatedProduct.ProductDescription;

            _productRepository.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();

            _productRepository.Remove(product);
            return Ok();
        }
    }
}
