using NakoShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Adddress> _repository;

        public CreateAddressCommandHandler(IRepository<Adddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Adddress
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
            });
        }
    }
}
