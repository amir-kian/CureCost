
using Mc2.CureCost.Domain.Commands;
using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Events;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Domain.ValueObjects;
using MediatR;
using PhoneNumbers;


namespace Mc2.CureCost.Service.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IWriteCustomerRepository _repository;
        private readonly ICustomerEventHandler _customerEventHandler;

        public CreateCustomerCommandHandler(IWriteCustomerRepository repository, ICustomerEventHandler customerEventHandler)
        {
            _repository = repository;
            _customerEventHandler = customerEventHandler;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            var email = new Email(request.Email);
            var bankAccountNumber = new BankAccountNumber(request.BankAccountNumber);

            var customer = new Customer(request.Firstname, request.Lastname, request.DateOfBirth, phoneNumber, email, bankAccountNumber);

            await _repository.Add(customer);

            var createdEvent = new CustomerCreatedEvent(
                customer.Id,
                customer.Firstname,
                customer.Lastname,
                customer.DateOfBirth,
                customer.PhoneNumber,
                customer.Email,
                customer.BankAccountNumber
            );
            await _customerEventHandler.Handle(createdEvent);

            return customer;
        }
    }
}
