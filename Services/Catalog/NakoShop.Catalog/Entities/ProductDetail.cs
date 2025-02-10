using MongoDB.Bson.Serialization.Attributes;

namespace NakoShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductDetaildID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
