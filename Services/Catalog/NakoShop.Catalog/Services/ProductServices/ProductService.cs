using AutoMapper;
using MongoDB.Driver;
using NakoShop.Catalog.Dtos.ProductDtos;
using NakoShop.Catalog.Entities;
using NakoShop.Catalog.Settings;

namespace NakoShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }


        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values  = _mapper.Map<Product>(createProductDto);
            await productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await productCollection.DeleteOneAsync( x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProduct()
        {
            var values = await productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
        {
            var values = await productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
