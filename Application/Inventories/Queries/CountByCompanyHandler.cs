using Application.Core;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories.Queries
{
    public class CountByCompanyHandler : IRequestHandler<CountByCompany, Result<int>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CountByCompanyHandler(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<Result<int>> Handle(CountByCompany request, CancellationToken cancellationToken)
        {
            var count = await _inventoryRepository.GetCountByCompany(request.CompanyPrefix);
            return Result<int>.Success(count);
        }
    }
}
