using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;

namespace NHLService
{

    //1 példány 1 adatbáziskapcsolat -> minden kérérst 1 példány 1 adatbáziskapcsolat szogál ki
    //Minden hívást 1 példány szolgáljon ki, ne jöjjön létre több példány
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]  //lehetne faultcontract is -> egyedi hibaüzenetekre
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
            //throw new ArgumentException("Hiba");
            return repo.GetAllMatches().Select(x => Mapper.Map<Entities.MatchData, NHLService.MatchData>(x)).ToList();
        }

        public List<GlobalResults> GetAllResults()
        {
            return repo.GetAllResults().Select(x => Mapper.Map<Entities.GlobalResults, NHLService.GlobalResults>(x)).ToList();
        }
    }
}
