using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Round : BaseEntity
    {
        [JsonPropertyName("sport_id")]
        public int SportId { get; set; } = default!;
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; } = default!;
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; } = default!;
        [JsonPropertyName("stage_id")]
        public int StageId { get; set; } = default!;
        [JsonPropertyName("is_current")]
        public bool Finished { get; set; }
        public bool IsCurrent { get; set; }
        [JsonPropertyName("starting_at")]
        public DateTime StartingAt { get; set; }
        [JsonPropertyName("ending_at")]
        public DateTime EndingAt { get; set; }
        [JsonPropertyName("games_in_current_week")]
        public bool GamesInCurrentWeek { get; set; }
    }
}