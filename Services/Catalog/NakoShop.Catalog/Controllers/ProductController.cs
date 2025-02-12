using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Catalog.Dtos.ProductDtos;
using NakoShop.Catalog.Services.ProductServices;

namespace NakoShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductServices;

        public ProductController(IProductService ProductServices)
        {
            _ProductServices = ProductServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _ProductServices.GetAllProduct();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _ProductServices.GetProductByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            await _ProductServices.CreateProductAsync(createProductDto);
            return Ok("Product Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            await _ProductServices.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _ProductServices.UpdateProductAsync(updateProductDto);
            return NoContent();
        }
    }
}
