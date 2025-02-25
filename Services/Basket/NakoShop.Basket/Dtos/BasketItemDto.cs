namespace NakoShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; } // catalog item id is string
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
