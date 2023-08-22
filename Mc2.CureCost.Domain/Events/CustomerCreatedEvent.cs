using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Domain.ValueObjects;

namespace Mc2.CureCost.Domain.Events
{
    public class CustomerCreatedEvent : IDomainEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public BankAccountNumber BankAccountNumber { get; set; }

        public CustomerCreatedEvent(int id, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
