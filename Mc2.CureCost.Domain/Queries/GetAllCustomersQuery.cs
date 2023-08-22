using Mc2.CureCost.Core.DTOs;
using MediatR;

namespace Mc2.CureCost.Domain.Queries
{
    public class GetAllCustomersQuery : IRequest<CustomerReadDTO[]>
    {
    }
}
