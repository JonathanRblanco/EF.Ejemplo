using MediatR;

namespace EF.Business.Commands
{
    public class TodoDeleteCommand : IRequest<TodoDeleteCommandResponse>
    {
        public int Id { get; init; }
    }
}
