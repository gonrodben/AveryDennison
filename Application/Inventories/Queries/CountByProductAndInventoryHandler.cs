using Application.Core;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByProductAndInventoryHandler : IRequestHandler<CountByProductAndInventory, Result<int>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CountByProductAndInventoryHandler(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<Result<int>> Handle(CountByProductAndInventory request, CancellationToken cancellationToken)
        {
            var count = await _inventoryRepository.GetCountByProductAndInventory(request.CompanyPrefix, request.ItemReference, request.InventoryId);
            return Result<int>.Success(count);
        }
    }
}
