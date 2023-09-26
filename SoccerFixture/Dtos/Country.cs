using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Country : BaseEntity
    {
        [JsonPropertyName("continent_id")]
        public int ContinentId { get; set; } = default!;
        [JsonPropertyName("official_name")]
        public string OfficialName { get; set; } = default!;
        [JsonPropertyName("fifa_name")]
        public string FifaName { get; set; } = default!;
        public string Iso2 { get; set; } = default!;
        public string Iso3 { get; set; } = default!;
        public string Latitude { get; set; } = default!;
        public string Longitude { get; set; } = default!;
        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; } = default!;
    }
}