using Entities.GenericsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IResultRepository : IRepository<results>
    {
        List<MatchData> GetAllMatches(); // team1+team2+goal1+goal2
        List<GlobalResults> GetAllResults(); // teamname + numberOfWins
    }

    public class GlobalResults
    {
        public string TeamName { get; set; }
        public int NumberOfWins { get; set; }
    }

    public class MatchData
    {
        public string TeamOne { get; set; }
        public string TeamTwo { get; set; }
        public int TeamOneGoals { get; set; }
        public int TeamTwoGoals{ get; set; }

    }
}
