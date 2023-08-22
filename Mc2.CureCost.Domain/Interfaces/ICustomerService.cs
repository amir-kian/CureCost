using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.ValueObjects;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email Email, BankAccountNumber bankAccountNumber);
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetAllCustomers();
        void UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber);
        void DeleteCustomer(int customerId);
    }
}
