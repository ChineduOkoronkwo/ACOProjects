namespace DbServiceAcceptanceTest.Products.Models
{
    public class BaseEntity : EntityId
    {
        public string Name { get; set; } = default!;
    }
}