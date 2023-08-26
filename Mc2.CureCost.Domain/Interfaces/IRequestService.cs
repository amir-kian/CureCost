using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.ValueObjects;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IRequestService
    {
        Request CreateRequest(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email Email, BankAccountNumber bankAccountNumber);
        Request GetRequestById(int RequestId);
        IEnumerable<Request> GetAllRequests();
        void UpdateRequest(int RequestId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber);
        void DeleteRequest(int RequestId);
    }
}
