using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class teams
    {
        public override string ToString()
        {
            return string.Format("Team id = {0} team name = {1} nad there are a lot of scores ", team_id, team_name);
        }
    }
    
}
