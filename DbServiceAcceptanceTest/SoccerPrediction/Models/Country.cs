namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class Country : BaseEntity
    {
        public Region Region { get; set; } = default!;
    }
}