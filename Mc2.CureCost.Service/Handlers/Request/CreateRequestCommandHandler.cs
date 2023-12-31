﻿
using Mc2.CureCost.Domain.Commands;
using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Events;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Domain.ValueObjects;
using MediatR;
using PhoneNumbers;
using PhoneNumber = Mc2.CureCost.Domain.ValueObjects.PhoneNumber;

namespace Mc2.CureCost.Service.Handlers
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Request>
    {
        private readonly IWriteRequestRepository _repository;
        private readonly IRequestEventHandler _requestEventHandler;

        public CreateRequestCommandHandler(IWriteRequestRepository repository, IRequestEventHandler requestEventHandler)
        {
            _repository = repository;
            _requestEventHandler = requestEventHandler;
        }

        public async Task<Request> Handle(CreateRequestCommand req, CancellationToken cancellationToken)
        {

            var request = new Request(req.Title, (Domain.Enums.RequestType)req.RequestType, req.Fund);

            await _repository.Add(request);

            var createdEvent = new RequestCreatedEvent(
                request.Id,
                request.Title,
               (int) request.RequestType,
                request.Fund
            );
            await _requestEventHandler.Handle(createdEvent);

            return request;
        }
    }
}
