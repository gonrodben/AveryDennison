using Application.Core;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByProductAndDate : IRequest<Result<int>>
    {
        public ulong CompanyPrefix { get; set; }
        public ulong ItemReference { get; set; }
        public DateTime InventoryDate { get; set; }
    }
}
