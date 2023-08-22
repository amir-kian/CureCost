using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Presentation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Repository
{
    public class ReadCustomerRepository : IReadCustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public ReadCustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Set<Customer>().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }
    }
}
