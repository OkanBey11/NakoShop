using NakoShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.OrderDetailId = command.OrderDetailId;
            values.OrderingId = command.OrderingId;
            values.ProductId = command.ProductId;
            values.ProductPrice = command.ProductPrice;
            values.ProductName = command.ProductName;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
