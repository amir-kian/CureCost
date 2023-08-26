using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Presentation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Repository
{
    public class ReadRequestRepository : IReadRequestRepository
    {
        private readonly AppDbContext _dbContext;

        public ReadRequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Request>> GetAll()
        {
            return await _dbContext.Set<Request>().ToListAsync();
        }

        public async Task<Request> GetById(int id)
        {
            return await _dbContext.Set<Request>().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Request>> GetAllRequests()
        {
            return await _dbContext.Set<Request>().ToListAsync();
        }
    }
}
