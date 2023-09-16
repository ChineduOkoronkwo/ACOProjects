using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServiceAcceptanceTest.Dtos
{
    public class ProductBase : BaseEntity
    {
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set;} = default!;
    }

    public class Product : ProductBase
    {
        public Guid BrandId { get; set; }
    }

    public class ProductWithBrand : ProductBase
    {
        public ProductBrand ProductBrand { get; set; } = default!;
    }
}