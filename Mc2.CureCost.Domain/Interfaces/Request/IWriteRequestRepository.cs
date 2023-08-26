using Mc2.CureCost.Domain.Entities;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IWriteRequestRepository
    {
        Task<int> Add(Request entity);
        Task Update(Request entity);
        Task Delete(Request entity);
        Task<Request> GetById(int id);
    }
}

