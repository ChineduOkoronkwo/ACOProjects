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
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public MatchResult MatchResult
        {
            get
            {
                if (HomeTeamScore == -1)
                {
                    return MatchResult.Unknown;
                }

                if (HomeTeamScore == AwayTeamScore)
                {
                    return MatchResult.Draw;
                }

                if (HomeTeamScore > AwayTeamScore)
                {
                    return MatchResult.HomeWin;
                }

                return MatchResult.AwayWin;
            }
        }
    }
}