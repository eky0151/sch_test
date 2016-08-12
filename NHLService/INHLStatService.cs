using System.ServiceModel;

namespace NHLService
{

    [ServiceContract]
    public interface INHLStatService
    {
        [OperationContract]
        System.Collections.Generic.List<MatchData> GetAllMatches();

        [OperationContract]
        System.Collections.Generic.List<GlobalResults> GetAllResults();
    }
}
