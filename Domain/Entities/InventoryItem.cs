namespace Domain.Entity
{
    public class InventoryItem
    {
        public string ItemHexCode { get; set; }
        public ulong ItemReference { get; set; }
        public ulong CompanyPrefix { get; set; }
        public ulong SerialReference { get; set; }
        public Inventory Inventory { get; set; }
    }
}

//normalize vs not normalize, data updates
//more disk space vs faster queries, plus scalability
