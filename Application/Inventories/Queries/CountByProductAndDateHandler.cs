using Application.Core;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByProductAndDateHandler : IRequestHandler<CountByProductAndDate, Result<int>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CountByProductAndDateHandler(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<Result<int>> Handle(CountByProductAndDate request, CancellationToken cancellationToken)
        {
            var count = await _inventoryRepository.GetCountByProductAndDate(request.CompanyPrefix, request.ItemReference, request.InventoryDate);
            return Result<int>.Success(count);
        }
    }
}
