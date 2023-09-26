using SoccerFixture.Models.BaseModels;
using SoccerFixture.Models.BaseModels.Core;

namespace SoccerFixture.Models.Core
{
    public class League : BaseEntity
    {
        public Country Country { get; set; } = default!;
        public Sport Sport { get; set; } = default!;
        public bool Active { get; set; }
        public string ShortCode { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string SubType { get; set; } = default!;
        public DateTime LastPlayedAt { get; set; }
        public int Category { get; set; }
        public bool HasJerseys { get; set; }
    }
}