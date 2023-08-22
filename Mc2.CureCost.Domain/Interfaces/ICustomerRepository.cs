using Mc2.CureCost.Domain.Entities;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetById(int customerId);
        void Update(Customer customer);
        void Delete(Customer customer);
        IEnumerable<Customer> GetAllCustomers();

    }
}
