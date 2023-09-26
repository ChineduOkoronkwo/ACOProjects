using SoccerFixture.Models.BaseModels;
using SoccerFixture.Models.BaseModels.Core;

namespace SoccerFixture.Models.Core
{
    public class Team : BaseEntity
    {
        public Sport Sport { get; set; } = default!;
        public Country Country { get; set; } = default!;
        public Venue Venue { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string ShortCode { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public int Founded { get; set; }
        public string Type { get; set; } = default!;
        public bool PlaceHolder { get; set; }
        public DateTime LastPlayedAt { get; set; }
    }
}