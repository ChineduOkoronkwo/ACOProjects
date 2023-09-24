namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class League : BaseEntity
    {
        public Country Country { get; set; } = default!;
    }
}