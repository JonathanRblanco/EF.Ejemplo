using MediatR;

namespace EF.Business.Commands
{
    public class TodoCreateCommand : IRequest<TodoCreateCommandResponse>
    {
        public string Description { get; init; }
    }
}
