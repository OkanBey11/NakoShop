using NakoShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;


        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductAmount = x.ProductAmount,
                OrderingId = x.OrderingId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
