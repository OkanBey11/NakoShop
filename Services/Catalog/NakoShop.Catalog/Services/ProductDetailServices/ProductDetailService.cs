using AutoMapper;
using MongoDB.Driver;
using NakoShop.Catalog.Dtos.ProductDetailDtos;
using NakoShop.Catalog.Entities;
using NakoShop.Catalog.Settings;

namespace NakoShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await productDetailCollection.DeleteOneAsync(x => x.ProductDetaildID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetail()
        {
            var values = await productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await productDetailCollection.Find<ProductDetail>(x => x.ProductDetaildID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetaildID == updateProductDetailDto.ProductDetaildID, values);
        }
    }
}
