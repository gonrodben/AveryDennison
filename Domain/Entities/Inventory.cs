namespace Domain.Entity
{
    public class Inventory
    {
        public string InventoryId { get; set; }
        public string Location { get; set; }
        public DateTime InventoryDate { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}
