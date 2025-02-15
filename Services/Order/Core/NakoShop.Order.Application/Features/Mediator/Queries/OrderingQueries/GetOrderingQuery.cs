using MediatR;
using NakoShop.Order.Application.Features.Mediator.Results.OrderingResaults;

namespace NakoShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResault>>
    {
    }
}
