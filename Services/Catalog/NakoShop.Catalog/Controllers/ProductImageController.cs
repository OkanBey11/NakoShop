using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Catalog.Dtos.ProductImageDtos;
using NakoShop.Catalog.Services.ProductImageServices;

namespace NakoShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageServices _ProductImageServices;

        public ProductImageController(IProductImageServices ProductImageServices)
        {
            _ProductImageServices = ProductImageServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageServices.GetAllProductImage();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _ProductImageServices.GetByIdProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageServices.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImageAsync(string id)
        {
            await _ProductImageServices.DeleteProductImageAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageServices.UpdateProductImageAsync(updateProductImageDto);
            return NoContent();
        }
    }
}
