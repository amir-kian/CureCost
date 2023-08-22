using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Presentation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Repository
{
    public class WriteCustomerRepository : IWriteCustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public WriteCustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task Delete(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
}
