using Mc2.CureCost.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace Mc2.CureCost.Domain.Events
{
    public class RequestEventHandler : IRequestEventHandler
    {
        private readonly ILogger<RequestEventHandler> _logger;
        private readonly IEventRepository<IDomainEvent> _eventRepository;

        public RequestEventHandler(ILogger<RequestEventHandler> logger, IEventRepository<IDomainEvent> eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task Handle(RequestCreatedEvent @event)
        {
            _logger.LogInformation($"Request {@event.Title} {@event.Fund} created with ID {@event.Id}");

            await _eventRepository.AddEvent(@event);
        }

        public async Task Handle(RequestUpdatedEvent @event)
        {
            _logger.LogInformation($"Request {@event.Title} {@event.Fund} updated with ID {@event.Id}");

            await _eventRepository.AddEvent(@event);
        }

        public async Task Handle(RequestDeletedEvent @event)
        {
            _logger.LogInformation($"Request with ID {@event.Id} deleted");

            await _eventRepository.AddEvent(@event);
        }
    }
}
