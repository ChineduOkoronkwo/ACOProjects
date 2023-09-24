namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class Season : BaseEntity
    {
        public Country Country { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}