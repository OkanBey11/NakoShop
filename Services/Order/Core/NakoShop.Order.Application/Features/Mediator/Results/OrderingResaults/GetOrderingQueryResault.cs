namespace NakoShop.Order.Application.Features.Mediator.Results.OrderingResaults
{
    public class GetOrderingQueryResault
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
