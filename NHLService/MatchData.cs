using System.Runtime.Serialization;

namespace NHLService
{
    //Data transfer object -> DTO
    [DataContract]
    public class MatchData
    {
        [DataMember]
        public string TeamOne { get; set; }

        [DataMember]
        public string TeamTwo { get; set; }

        [DataMember]
        public int TeamOneGoals { get; set; }

        [DataMember]
        public int TeamTwoGoals { get; set; }

    }
}
