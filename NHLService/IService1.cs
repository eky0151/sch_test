using System.Runtime.Serialization;
using System.ServiceModel;

namespace NHLService
{

    [ServiceContract]
    public interface INHLService
    {
        [OperationContract]
        System.Collections.Generic.List<MatchData> GetAllMatches();

        [OperationContract]
        System.Collections.Generic.List<GlobalResults> GetAllResults();
    }
}
