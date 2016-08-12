using Entities;
using System;

namespace RepoTest
{
    class Program
    {
        static ITeamRepo teamRepo;
        static IResultRepository resultRepo;

        static void Main(string[] args)
        {
            NHLDatabaseEntities context = new NHLDatabaseEntities();
            
            teamRepo = new TeamRepository(context);

            resultRepo = new ResultRepository(context);

            foreach (var i in teamRepo.GetAll())
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("ADD NEW TEAM------------");

            teams team = new teams();
            team.team_name = "Detroit Red Wings";
            teamRepo.Insert(team);

            foreach (var i in teamRepo.GetAll())
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("RESULTS------------");

            foreach (var item in resultRepo.GetAllResults())
            {
                Console.WriteLine("{0}: {1}", item.TeamName, item.NumberOfWins);
            }

            Console.WriteLine("MATCHES  ------------");

            foreach (var item in resultRepo.GetAllMatches())
            {
                Console.WriteLine("{0} : {1} ||| {2} : {3} ", item.TeamOne, item.TeamOneGoals, item.TeamTwo, item.TeamTwoGoals);
            }

            Console.ReadLine();
        }
    }
}
