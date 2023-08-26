using Mc2.CureCost.Domain.Enums;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Domain.ValueObjects;
using System;

namespace Mc2.CureCost.Domain.Events
{
    public class RequestUpdatedEvent : IDomainEvent
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int RequestType { get; set; }
        public double Fund { get; set; }

        public RequestUpdatedEvent(int id, string title, int requestType, double fund)
        {
            Id = id;
            Title = title;
            RequestType = requestType;
            Fund = fund;
        }




    }


}
