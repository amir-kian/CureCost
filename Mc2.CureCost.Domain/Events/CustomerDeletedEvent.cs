using Mc2.CureCost.Domain.Interfaces;

namespace Mc2.CureCost.Domain.Events
{
    public class CustomerDeletedEvent : IDomainEvent
    {
        public CustomerDeletedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
