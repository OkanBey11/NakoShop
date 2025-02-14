using NakoShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Adddress> _adddressRepository;

        public RemoveAddressCommandHandler(IRepository<Adddress> adddressRepository)
        {
            _adddressRepository = adddressRepository;
        }

        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var value = await _adddressRepository.GetByIdAsync(removeAddressCommand.Id);
            await _adddressRepository.DeleteAsync(value);
        }
    }
}
