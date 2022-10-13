using Application.Core;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByCompany : IRequest<Result<int>>
    {
        public ulong CompanyPrefix { get; set; }
    }
}
