using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHLService
{
        //Data transfer object -> DTO
        [DataContract]
        public class GlobalResults
        {
            [DataMember]
            public string TeamName { get; set; }

            [DataMember]
            public int NumberOfWins { get; set; }
        }
   
    
}
