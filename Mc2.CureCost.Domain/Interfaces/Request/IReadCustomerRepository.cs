using Mc2.CureCost.Domain.Entities;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IReadRequestRepository
    {
        Task<Request> GetById(int id);
        Task<List<Request>> GetAll();
        Task<List<Request>> GetAllRequests();
    }
}
