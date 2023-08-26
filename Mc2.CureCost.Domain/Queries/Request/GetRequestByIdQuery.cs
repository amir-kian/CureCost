using Mc2.CureCost.Core.DTOs;
using MediatR;

namespace Mc2.CureCost.Domain.Queries
{
    public class GetRequestByIdQuery : IRequest<RequestReadDTO>
    {
        public int CustomerId { get; set; }
    }
}
