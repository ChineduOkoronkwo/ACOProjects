using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class League : BaseEntity
    {
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; } = default!;
        [JsonPropertyName("sport_id")]
        public int SportId { get; set; } = default!;
        public bool Active { get; set; }
        [JsonPropertyName("short_code")]
        public string ShortCode { get; set; } = default!;
        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; } = default!;
        public string Type { get; set; } = default!;
        [JsonPropertyName("sub_type")]
        public string SubType { get; set; } = default!;
        [JsonPropertyName("last_played_at")]
        public DateTime LastPlayedAt { get; set; }
        public int Category { get; set; }
        [JsonPropertyName("has_jerseys")]
        public bool HasJerseys { get; set; }
    }
}