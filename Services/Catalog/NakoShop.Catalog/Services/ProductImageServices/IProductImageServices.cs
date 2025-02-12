using NakoShop.Catalog.Dtos.ProductImageDtos;

namespace NakoShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageServices
    {
        Task<List<ResultProductImageDto>> GetAllProductImage();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
