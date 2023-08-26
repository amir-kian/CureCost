using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Presentation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Repository
{
    public class WriteRequestRepository : IWriteRequestRepository
    {
        private readonly AppDbContext _dbContext;

        public WriteRequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Request customer)
        {
            await _dbContext.Requests.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task Delete(Request customer)
        {
            _dbContext.Requests.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Request customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Request> GetById(int id)
        {
            return await _dbContext.Requests.FindAsync(id);
        }
    }
}
