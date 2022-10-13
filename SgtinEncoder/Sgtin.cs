namespace SgtinEncoder
{
    public class Sgtin
    {
        public static SgtinTag Decode(string hexText)
        {
            var bitArray = hexText.ToBitArray();
            uint header = bitArray.ToUInt(0, 8);

            switch (header)
            {
                case SgtinTag96.TagHeader:
                    return SgtinTag96.FromHex(hexText);
                default:
                    throw new ArgumentException($"No implementation found for the EPC code: {hexText}");
            }
        }
    }
}
