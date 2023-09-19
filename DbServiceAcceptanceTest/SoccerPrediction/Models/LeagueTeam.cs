using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServiceAcceptanceTest.SoccerPrediction.Models
{
    public class LeagueTeam : EntityId
    {
        public Team Team { get; set; } = default!;
        public League League { get; set; } = default!;
        public Season Season { get; set; } = default!;
    }
}