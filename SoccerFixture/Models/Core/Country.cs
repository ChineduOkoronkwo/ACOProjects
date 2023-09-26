using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Models.Core
{
    public class Country : BaseEntity
    {
        public Continent Continent { get; set; } = default!;
        public string OfficialName { get; set; } = default!;
        public string FifaName { get; set; } = default!;
        public string Iso2 { get; set; } = default!;
        public string Iso3 { get; set; } = default!;
        public string Latitude { get; set; } = default!;
        public string Longitude { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
    }
}