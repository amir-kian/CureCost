﻿namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}
