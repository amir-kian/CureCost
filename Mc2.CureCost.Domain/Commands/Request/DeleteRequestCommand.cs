using MediatR;

namespace Mc2.CureCost.Domain.Commands
{
    public class DeleteRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteRequestCommand(int id)
        {
            Id = id;
        }
    }
}