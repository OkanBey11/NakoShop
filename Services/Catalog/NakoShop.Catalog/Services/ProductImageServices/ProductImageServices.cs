using AutoMapper;
using MongoDB.Driver;
using NakoShop.Catalog.Dtos.ProductImageDtos;
using NakoShop.Catalog.Entities;
using NakoShop.Catalog.Settings;

namespace NakoShop.Catalog.Services.ProductImageServices
{
    public class ProductImageServices : IProductImageServices
    {
        private readonly IMongoCollection<ProductImage> _categoriesCollection;
        private readonly IMapper _mapper;

        public ProductImageServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoriesCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _categoriesCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _categoriesCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImage()
        {
            var values = await _categoriesCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _categoriesCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _categoriesCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }
    }
}
