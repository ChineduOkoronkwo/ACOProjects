using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public enum MatchResult
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("1")]
        HomeWin = 1,
        [Description("2")]
        AwayWin = 2,
        [Description("X")]
        Draw = 3,
    }

    public class FixtureResult : EntityId
    {
        public Fixture Fixture { get; set; } = default!;
        public int HomeLeagueTeamScore { get; set; }
        public int AwayLeagueTeamScore { get; set; }
        public MatchResult MatchResult
        {
            get
            {
                switch (HomeLeagueTeamScore.CompareTo(AwayLeagueTeamScore))
                {
                    case -1:
                        return MatchResult.AwayWin;
                    case 0:
                        return MatchResult.Draw;
                    case 1:
                        return MatchResult.HomeWin;
                    default:
                        throw new InvalidOperationException("Invalid match result");
                }
            }
        }
    }
}