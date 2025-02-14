﻿using NakoShop.Order.Application.Features.CQRS.Results.AddressResults;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Adddress> _adddressRepository;

        public GetAddressQueryHandler(IRepository<Adddress> adddressRepository)
        {
            _adddressRepository = adddressRepository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _adddressRepository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
