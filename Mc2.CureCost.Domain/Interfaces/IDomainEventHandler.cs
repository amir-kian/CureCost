namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent @event);
    }
}
