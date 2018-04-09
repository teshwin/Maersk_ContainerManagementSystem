using CMSMaersk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CMSMaersk.DAL
{
    public class AgentRepository : Repository<Agent>
    {
        public Agent AuthenticateCredentials(string username, string password)
        {
            var obj = DbSet.Where(a => a.Username == username && a.Password == password).ToList<Agent>();
            if (obj.Count == 0)
                return null;
            else
                return obj[0];
        }
    }
}