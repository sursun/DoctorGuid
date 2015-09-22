using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class TerminalRepository : RepositoryBase<Terminal>, ITerminalRepository
    {
        protected override IQueryable<Terminal> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Terminal> q = base.LoadQuery(query);
            var sysLogQuery = query as TerminalQuery;
            if (sysLogQuery == null) return q;

            //if (!string.IsNullOrEmpty(sysLogQuery.LogInfo))
            //{
            //    q = q.Where(c => c.LogInfo.Contains(sysLogQuery.LogInfo));
            //}

            //if (!string.IsNullOrEmpty(sysLogQuery.LoginName))
            //{
            //    q = q.Where(c => c.User.LoginName.Contains(sysLogQuery.LoginName));
            //}

            //if (sysLogQuery.CreateTime != null)
            //{
            //    if (sysLogQuery.CreateTime.Start.HasValue)
            //    {
            //        q = q.Where(c => c.CreateTime >= sysLogQuery.CreateTime.Start);
            //    }

            //    if (sysLogQuery.CreateTime.End.HasValue)
            //    {
            //        q = q.Where(c => c.CreateTime < sysLogQuery.CreateTime.End);
            //    }
            //}

            return q;
        }

        public Terminal GetBy(string mac)
        {
            return Query.FirstOrDefault(c => c.Mac.ToLower().Equals(mac.ToLower()));
        }



    }
}
