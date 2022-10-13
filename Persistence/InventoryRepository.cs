using Domain.Entity;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<InventoryItem> AllItems;

        public InventoryRepository()
        {
            AllItems = new List<InventoryItem>();
        }

        public async Task AddInventory(Inventory inventory)
        {
            foreach(var item in inventory.Items)
                item.Inventory = inventory;

            await Task.Run(() => AllItems.AddRange(inventory.Items));
        }

        public async Task<int> GetCountByProductAndInventory(ulong companyPrefix, ulong itemReference, string inventoryId)
        {   
            var result = await Task.Run(() => AllItems.Count(item => item.Inventory.InventoryId == inventoryId &&
                                                                     item.CompanyPrefix == companyPrefix &&
                                                                     item.ItemReference == itemReference));
            return result;
        }

        public async Task<int> GetCountByProductAndDate(ulong companyPrefix, ulong itemReference, DateTime inventoryDate)
        {
            var result = await Task.Run(() => AllItems.Count(item => item.Inventory.InventoryDate.Date == inventoryDate.Date &&
                                                                    item.CompanyPrefix == companyPrefix &&
                                                                    item.ItemReference == itemReference));
            return result;
        }

        public async Task<int> GetCountByCompany(ulong companyPrefix)
        {
            var result = await Task.Run(() => AllItems.Count(item => item.CompanyPrefix == companyPrefix));
            return result;
        }
    }
}
