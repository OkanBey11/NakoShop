﻿namespace NakoShop.Order.Application.Features.Mediator.Results.OrderingResaults
{
    public class GetOrderingByIdQueryResault
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
