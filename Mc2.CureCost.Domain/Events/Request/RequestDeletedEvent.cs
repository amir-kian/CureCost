using Mc2.CureCost.Domain.Interfaces;

namespace Mc2.CureCost.Domain.Events
{
    public class RequestDeletedEvent : IDomainEvent
    {
        public RequestDeletedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
