using Mc2.CureCost.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CureCost.Domain.Entities
{
    public class Event : IDomainEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
