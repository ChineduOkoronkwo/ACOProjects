namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class Fixture : EntityId
    {
        public LeagueTeam HomeLeagueTeam { get; set; } = default!;
        public LeagueTeam AwayLeagueTeam { get; set; } = default!;
        public DateTimeOffset MatchDateTime { get; set; }
        public MatchRound MatchRound { get; set; } = default!;
        public Status Status { get; set; } = default!;
    }
}