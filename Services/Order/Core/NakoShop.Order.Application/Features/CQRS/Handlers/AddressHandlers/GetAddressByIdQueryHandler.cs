using NakoShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using NakoShop.Order.Application.Features.CQRS.Results.AddressResults;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Adddress> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Adddress> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _addressRepository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                UserId = value.UserId,
            };
        }
    }
}
