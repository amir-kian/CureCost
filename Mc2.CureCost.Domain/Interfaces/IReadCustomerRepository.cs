using Mc2.CureCost.Domain.Entities;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IReadCustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task<List<Customer>> GetAllCustomers();
    }
}
