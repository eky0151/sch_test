using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TeamRepository : GenericsRepository.GenericsEFRepo<teams>, ITeamRepo
    {
        public TeamRepository(DbContext newContext) : base(newContext)
        {
        }


        public override teams GetById(int id)
        {
            return Get(x => x.team_id == id).SingleOrDefault();
        }

        public int GetTeamId()
        {
            var rawQuery = context.Database.SqlQuery<int>("select next value for seq_teams");
            return rawQuery.Single();
        }

        public override void Insert(teams newEntity)
        {
            newEntity.team_id = GetTeamId();
            base.Insert(newEntity);
        }
    }
}
