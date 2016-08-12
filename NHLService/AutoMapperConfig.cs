using AutoMapper;
using System.Linq.Expressions;

namespace NHLService
{
    public class AutoMapperConfig //4.0.0.0 - alpha
    {
        public static void Init()
        {
            //repository-bol 
            Mapper.CreateMap<Entities.MatchData, NHLService.MatchData>(); //típusból típusba másol név szerint
            Mapper.CreateMap<Entities.GlobalResults, NHLService.GlobalResults>();

            // Mapper.CreateMap<Entities.GlobalResults, NHLService.GlobalResults>().ForMember(x => x.TeamName, opt => opt.Ignore());
            //Mapper.CreateMap<Entities.GlobalResults, NHLService.GlobalResults>().ForMember(x => x.NumberOfWins, opt => opt.MapFrom(src => src.TeamName));

        }
    }
}
