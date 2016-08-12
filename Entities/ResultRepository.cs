using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResultRepository : GenericsRepository.GenericsEFRepo<results>, IResultRepository
    {
        public ResultRepository(DbContext newContext) : base(newContext)
        {
        }

        public List<MatchData> GetAllMatches()
        {
            var q = from result in context.Set<results>()
                    join scoreOne in context.Set<scores>() on result.result_score1 equals scoreOne.score_id
                    join scoreTwo in context.Set<scores>() on result.result_score2 equals scoreTwo.score_id
                    join team1 in context.Set<teams>() on scoreOne.score_team equals team1.team_id
                    join team2 in context.Set<teams>() on scoreTwo.score_team equals team2.team_id
                    select new MatchData
                    {
                        TeamOne = team1.team_name,
                        TeamTwo = team2.team_name,
                        TeamOneGoals = scoreOne.score_goals.Value,
                        TeamTwoGoals = scoreTwo.score_goals.Value
                    };

            //ha null elszáll 

            var q2 = from res in context.Set<results>()
                     select new MatchData
                     {
                         TeamOne = res.scores.teams.team_name,
                         TeamTwo = res.scores1.teams.team_name,
                         TeamOneGoals = res.scores.score_goals.Value,
                         TeamTwoGoals = res.scores.score_goals.Value
                     };

            //TeamOne = res?.scores?.teams?.team_name,

            return q.ToList();

        }

        public List<GlobalResults> GetAllResults()
        {
            //sql-lel
            string sql = @"SELECT sub.num as NumberOfWins, team_name as TeamName
                              FROM (
                                        SELECT count(1) as num, score_team
                                        FROM scores
                                        GROUP BY score_team
                                   ) sub, teams
                              WHERE sub.score_team = team_id";

            //return context.Database.SqlQuery<GlobalResults>(sql).ToList();



            var q = from i in context.Set<scores>()
                    group i by i.teams into g
                    select new GlobalResults
                    {
                        NumberOfWins = g.Count(X => X.score_wins == 1),
                        TeamName = g.Key.team_name

                    };

            Console.WriteLine("SQL : {0} \r\n\r EF : {1}",sql,q );
            return q.ToList();
        }

        public override results GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.result_id == id);
        }
    }
}
