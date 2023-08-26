using Mc2.CureCost.Domain.Entities;
using MediatR;

namespace Mc2.CureCost.Domain.Commands
{
    public class CreateRequestCommand : IRequest<Request>
    {
        public string Title { get; set; }
        public int RequestType { get; set; }
        public double Fund { get; set; }

        public CreateRequestCommand(string title, int requestType, double fund)
        {
            Title = title;
            RequestType = requestType;
            Fund = fund;

        }
    }
}
