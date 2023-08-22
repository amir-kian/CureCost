using Mc2.CureCost.Domain.Events;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface ICustomerEventHandler
    {
        Task Handle(CustomerCreatedEvent @event);
        Task Handle(CustomerUpdatedEvent @event);
        Task Handle(CustomerDeletedEvent @event);
    }
}
