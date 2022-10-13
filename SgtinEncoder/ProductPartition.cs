using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgtinEncoder
{
    internal class ProductPartition
    {
        public int CompanyBits { get; }
        public int CompanyDigits { get; }
        public int ItemBits { get; }
        public int ItemDigits { get; }

        public ProductPartition(int companyBits, int companyDigits, int itemBits, int itemDigits)
        {
            CompanyBits = companyBits;
            CompanyDigits = companyDigits;
            ItemBits = itemBits;
            ItemDigits = itemDigits;    
        }

        public static ProductPartition[] List()
        {
            return new ProductPartition[] {
                new ProductPartition(40, 12, 4, 1),
                new ProductPartition(37, 11, 7, 2),
                new ProductPartition(34, 10, 10, 3),
                new ProductPartition(30, 9, 14, 4),
                new ProductPartition(27, 8, 17, 5),
                new ProductPartition(24, 7, 20, 6),
                new ProductPartition(20, 6, 24, 7) 
            };
        }
    }
}
