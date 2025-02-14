using NakoShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using NakoShop.Order.Application.Interfaces;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Adddress> _adddressRepository;

        public UpdateAddressCommandHandler(IRepository<Adddress> adddressRepository)
        {
            _adddressRepository = adddressRepository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _adddressRepository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Detail = updateAddressCommand.Detail;
            values.District = updateAddressCommand.District;
            values.City = updateAddressCommand.City;
            values.UserId = updateAddressCommand.UserId;
            await _adddressRepository.UpdateAsync(values);
        }
    }
}
