using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgtinEncoder
{
    internal class SgtinTag96 : SgtinTag
    {
        public override SgtinTagType Type => SgtinTagType.Sgtin_96;
        public const uint TagHeader = 0x30;

        public SgtinTag96(uint filter, uint partition, ulong companyPrefix, ulong itemReference, ulong serialReference) :
            base(filter, partition, companyPrefix, itemReference, serialReference)
        {
        }

        public static SgtinTag FromHex(string hexText)
        {
            var bitArray = hexText.ToBitArray();

            if (bitArray.Length != 96)
                throw new ArgumentException($"Invalid EPC code: {hexText}. bits length is {bitArray.Length} instead of 96");

            uint header = bitArray.ToUInt(0, 8);

            if (header != TagHeader)
                throw new FormatException(string.Format($"Invalid Sgtin-96 tag header: {header}"));

            uint filter = bitArray.ToUInt(8, 3);
            uint partition = bitArray.ToUInt(11, 3);

            var productPartition = ProductPartition.List()[partition];

            ulong companyPrefix = bitArray.ToULong(14, productPartition.CompanyBits);
            ulong itemReference = bitArray.ToULong(14 + productPartition.CompanyBits, productPartition.ItemBits);

            //var companyPrefix = companyValue.ToString().PadLeft(productPartition.CompanyDigits, '0');
            //var itemNumber = itemValue.ToString().PadLeft(productPartition.ItemDigits, '0');

            var serialReference = bitArray.ToULong(58, 38);

            return new SgtinTag96(filter, partition, companyPrefix, itemReference, serialReference);
        }


    }
}
