using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Team : BaseEntity
    {
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; } = default!;
        [JsonPropertyName("sport_id")]
        public int SportId { get; set; } = default!;
        [JsonPropertyName("venue_id")]
        public int VenueId { get; set; } = default!;
        public string Gender { get; set; } = default!;
        [JsonPropertyName("short_code")]
        public string ShortCode { get; set; } = default!;
        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; } = default!;
        public int Founded { get; set; }
        public string Type { get; set; } = default!;
        public bool PlaceHolder { get; set; }
        [JsonPropertyName("last_played_at")]
        public DateTime LastPlayedAt { get; set; }
    }
}