using System.Collections;
using System.Globalization;

namespace SgtinEncoder
{
    internal static class ConversionExtension
    {
        public static BitArray ToBitArray(this string hexText)
        {
            BitArray bitArray = new BitArray(4 * hexText.Length);
            for (int i = 0; i < hexText.Length; i++)
            {
                byte b = byte.Parse(hexText[i].ToString(), NumberStyles.HexNumber);
                for (int j = 0; j < 4; j++)
                {
                    bitArray[i * 4 + j] = (b & (1 << (3 - j))) != 0;
                }
            }

            return bitArray;
        }

        public static uint ToUInt(this BitArray bitArray, int start, int count)
        {
            if (start < 0 || bitArray.Length - start - count < 0)
                throw new ArgumentOutOfRangeException($"Start position: {start}; count: {count}; Lenght: {bitArray.Length}");

            uint result = 0;
            for (int i = 0; i < count; i++)
            {
                if (bitArray[start + count - i - 1])
                    result |= 1u << i;
            }

            return result;
        }

        public static ulong ToULong(this BitArray bitArray, int start, int count)
        {
            if (start < 0 || bitArray.Length - start - count < 0)
                throw new ArgumentOutOfRangeException($"Start position: {start}; count: {count}; Lenght: {bitArray.Length}");

            ulong result = 0;
            for (int i = 0; i < count; i++)
            {
                if (bitArray[start + count - i - 1])
                    result |= 1ul << i;
            }

            return result;
        }
    }
}
