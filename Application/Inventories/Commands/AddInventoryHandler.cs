using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories
{
    public class AddInventoryHandler : IRequestHandler<AddInventoryCommand, Result<Unit>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public AddInventoryHandler(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<Result<Unit>> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {
            var items = request.Tags.Select(tag => BuidItem(tag))
                                    .ToList();

            var inventory = new Inventory
            {
                InventoryId = request.InventoryId,
                Location = request.Location,
                InventoryDate = request.Date,
                Items = items,
            };

            await _inventoryRepository.AddInventory(inventory);

            return Result<Unit>.Success(Unit.Value);
        }

        private InventoryItem BuidItem(string code)
        {
            var tag = SgtinEncoder.Sgtin.Decode(code);

            var item = new InventoryItem
            {
                ItemHexCode = code,
                CompanyPrefix = tag.CompanyPrefix,
                ItemReference = tag.ItemReference,
                SerialReference = tag.SerialReference
            };

            return item;
        }
    }
}