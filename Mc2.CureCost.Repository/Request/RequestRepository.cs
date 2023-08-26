
using Mc2.CureCost.Domain.Entities;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Presentation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _dbContext;

        public RequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Request Request)
        {
            _dbContext.Set<Request>().Add(Request);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _dbContext.Set<Request>().ToList();
        }

        public Request GetById(int RequestId)
        {
            return _dbContext.Set<Request>().SingleOrDefault(c => c.Id == RequestId);
        }

        public void Update(Request Request)
        {
            _dbContext.Entry(Request).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Request Request)
        {
            _dbContext.Set<Request>().Remove(Request);
            _dbContext.SaveChanges();
        }
    }
}