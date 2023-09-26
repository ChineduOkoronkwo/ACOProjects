using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Fixture : BaseEntity
    {
        [JsonPropertyName("sport_id")]
        public int SportId { get; set; } = default!;
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; } = default!;
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; } = default!;
        [JsonPropertyName("stage_id")]
        public int StageId { get; set; } = default!;
        [JsonPropertyName("group_id")]
        public int? GroupId { get; set; } = default!;
        [JsonPropertyName("aggregate_id")]
        public int? AggregateId { get; set; } = default!;
        [JsonPropertyName("round_id")]
        public int RoundId { get; set; } = default!;
        [JsonPropertyName("state_id")]
        public int StateId { get; set; } = default!;
        [JsonPropertyName("venue_id")]
        public int VenueId { get; set; } = default!;
        [JsonPropertyName("starting_at")]
        public DateTimeOffset StartingAt { get; set; }
        [JsonPropertyName("result_info")]
        public string ResultInfo { get; set; } = default!;
        public string Leg { get; set; } = default!;
        public int Length { get; set; }
        public bool Placeholder { get; set; }
        [JsonPropertyName("has_odds")]
        public bool HasOdds { get; set; }
        [JsonPropertyName("starting_at_timestamp")]
        public long StartingAtimestamp { get; set; }
    }
}