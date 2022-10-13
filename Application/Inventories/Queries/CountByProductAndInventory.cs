using Application.Core;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByProductAndInventory : IRequest<Result<int>>
    {
        public ulong CompanyPrefix { get; set; }
        public ulong ItemReference { get; set; }
        public string InventoryId { get; set; }
    }
}
