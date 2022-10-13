namespace SgtinEncoder
{
    public abstract class SgtinTag
    {
        public abstract SgtinTagType Type { get; }
        public uint Filter { get; }
        public uint Partition { get; }
        public ulong CompanyPrefix { get; }
        public ulong ItemReference { get; }
        public ulong SerialReference { get; }

        protected SgtinTag(uint filter, uint partition, ulong companyPrefix, ulong itemReference, ulong serialReference)
        {
            Filter = filter;
            Partition = partition;
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
            SerialReference = serialReference;
        }
    }
}
