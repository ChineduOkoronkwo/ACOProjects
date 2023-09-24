namespace DbServiceAcceptanceTest.Products.Models
{
    public class ProductMedia : EntityId
    {
        public string MediaUrl { get; set; } = default!;
        public bool IsDisplayPicture { get; set; }
        public Product Product { get; set; } = default!;
    }
}