namespace DbServiceAcceptanceTest.Products.Models
{
    public class Product : BaseEntity
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public Currency Currency { get; set; } = default!;
        public ProductBrand ProductBrand { get; set; } = default!;
    }
}