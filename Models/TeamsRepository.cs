using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public class TeamsRepository
    {
        DBContext db = new DBContext();

        public List<Teams> GetTeams()
        {
            return db.Teams.ToList();
        }
   
    }
}