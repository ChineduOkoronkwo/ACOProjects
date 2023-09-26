using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Season : BaseEntity
    {
        [JsonPropertyName("sport_id")]
        public int SportId { get; set; } = default!;
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; } = default!;
        [JsonPropertyName("tie_breaker_rule_id")]
        public int TieBreakerRuleId { get; set; }
        public bool Finished { get; set; }
        public bool Pending { get; set; }
        [JsonPropertyName("is_current")]
        public bool IsCurrent { get; set; }
        [JsonPropertyName("starting_at")]
        public DateTime StartingAt { get; set; }
        [JsonPropertyName("ending_at")]
        public DateTime EndingAt { get; set; }
        [JsonPropertyName("standings_recalculated_at")]
        public DateTime StandingsRecalculatedAt { get; set; }
        [JsonPropertyName("games_in_current_week")]
        public bool GamesInCurrentWeek { get; set; }
    }
}