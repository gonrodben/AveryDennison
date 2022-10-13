using Domain.Entity;

namespace Domain.Repositories
{
    public interface IInventoryRepository
    {
        Task AddInventory(Inventory inventory);
        Task<int> GetCountByProductAndInventory(ulong companyPrefix, ulong itemReference, string inventoryId);
        Task<int> GetCountByProductAndDate(ulong companyPrefix, ulong itemReference, DateTime inventoryDate);
        Task<int> GetCountByCompany(ulong companyPrefix);
    }
}
