using Mc2.CureCost.Domain.Events;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IRequestEventHandler
    {
        Task Handle(RequestCreatedEvent @event);
        Task Handle(RequestUpdatedEvent @event);
        Task Handle(RequestDeletedEvent @event);
    }
}
