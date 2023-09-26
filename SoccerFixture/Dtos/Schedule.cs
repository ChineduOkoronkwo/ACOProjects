using System.Text.Json.Serialization;
using SoccerFixture.Models.BaseModels;

namespace SoccerFixture.Dtos
{
    public class Schedule
    {
        public IEnumerable<ScheduleSeason> Schedules { get; set; } = default!;
    }

    public class ScheduleSeason : Season
    {
        public IEnumerable<ScheduleRound> Rounds { get; set; } = default!;
    }

    public class ScheduleRound : Round
    {
        public IEnumerable<ScheduleFixture> Fixtures { get; set; } = default!;
    }

    public class ScheduleFixture : Fixture
    {
        public IEnumerable<ScheduleParticipant> Participants { get; set; } = default!;
        public IEnumerable<FixtureScore> Scores { get; set; } = default!;
    }

    public class ScheduleParticipant : Team
    {
        public Meta Meta { get; set; } = default!;
    }

    public class Meta
    {
        public string Location { get; set; } = default!;
        public bool Winner { get; set; }
        public int Position { get; set; }
    }

    public class FixtureScore : EntityId
    {
        [JsonPropertyName("fixture_id")]
        public int FixtureId { get; set; }
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }
        [JsonPropertyName("participant_id")]
        public int ParticipantId { get; set; }
        public Score Score { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public class Score
    {
        public int Goals { get; set; }
        public string Participant { get; set; } = default!;
    }
}