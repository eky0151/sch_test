using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace NHLService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] //Minden hívást 1 példány szolgáljon ki, ne jöjjön létre több példány
    //1 példány 1 adatbáziskapcsolat -> minden kérérst 1 példány 1 adatbáziskapcsolat szogál ki
    public class NHLStatService : INHLStatService
    {
        IResultRepository repo;

        public NHLStatService()
        {
            AutoMapperConfig.Init();
            NHLDatabaseEntities entities = new NHLDatabaseEntities();
            repo = new ResultRepository(entities);
        }

        public List<MatchData> GetAllMatches()
        {
            return repo.GetAllMatches().Select(x => Mapper.Map<Entities.MatchData, NHLService.MatchData>(x)).ToList();
        }

        public List<GlobalResults> GetAllResults()
        {
            return repo.GetAllMatches().Select(x => Mapper.Map<Entities.GlobalResults, NHLService.GlobalResults>(x)).ToList();
        }
    }
}
