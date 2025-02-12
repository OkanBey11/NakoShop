using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Catalog.Dtos.ProductDetailDtos;
using NakoShop.Catalog.Services.ProductDetailServices;

namespace NakoShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailServices;

        public ProductDetailController(IProductDetailService ProductDetailServices)
        {
            _ProductDetailServices = ProductDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailServices.GetAllProductDetail();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _ProductDetailServices.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailServices.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetailAsync(string id)
        {
            await _ProductDetailServices.DeleteProductDetailAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailServices.UpdateProductDetailAsync(updateProductDetailDto);
            return NoContent();
        }
    }
}
