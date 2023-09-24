namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class Team : BaseEntity
    {
        public Country Country { get; set; } = default!;
    }
}