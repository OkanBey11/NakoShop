using MediatR;

namespace NakoShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrederingCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrederingCommand(int id)
        {
            Id = id;
        }
    }
}
