using NakoShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using NakoShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResault> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResault
            {
                OrderDetailId = values.OrderDetailId,
                ProductAmount = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                OrderingId = values.OrderingId,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
            };
        }
    }
}
