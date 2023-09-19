using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class Fixture : EntityId
    {
        public LeagueTeam HomeTeam { get; set; } = default!;
        public LeagueTeam AwayTeam { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public MatchRound MatchRound { get; set; } = default!;
        public Status Status { get; set; } = default!;
    }
}