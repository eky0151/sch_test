using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NHLService
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            //repository-bol 
            Mapper.CreateMap<Entities.MatchData, NHLService.MatchData>();
            Mapper.CreateMap<Entities.GlobalResults, NHLService.GlobalResults>();
        }
    }
}
