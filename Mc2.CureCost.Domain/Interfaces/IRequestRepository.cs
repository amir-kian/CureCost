using Mc2.CureCost.Domain.Entities;

namespace Mc2.CureCost.Domain.Interfaces
{
    public interface IRequestRepository
    {
        void Add(Request Request);
        Request GetById(int RequestId);
        void Update(Request Request);
        void Delete(Request Request);
        IEnumerable<Request> GetAllRequests();

    }
}
