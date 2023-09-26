using SoccerFixture.Models.BaseModels;
using SoccerFixture.Models.BaseModels.Core;

namespace SoccerFixture.Models.Core
{
    public class Season : BaseEntity
    {
        public Sport Sport { get; set; } = default!;
        public League League { get; set; } = default!;
        public int TieBreakerRuleId { get; set; }
        public bool Finished { get; set; }
        public bool Pending { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public DateTime StandingsRecalculatedAt { get; set; }
        public bool GamesInCurrentWeek { get; set; }
    }
}