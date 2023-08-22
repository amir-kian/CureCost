using Mc2.CureCost.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Mc2.CureCost.Domain.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventRepository<IDomainEvent> _eventRepository;

        public EventDispatcher(IServiceProvider serviceProvider, IEventRepository<IDomainEvent> eventRepository)
        {
            _serviceProvider = serviceProvider;
            _eventRepository = eventRepository;
        }

        public void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }

            _eventRepository.AddEvent(@event);
        }
    }
}
