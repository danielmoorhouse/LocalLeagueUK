using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public partial class Matches
    {
        TeamsRepository teams = new TeamsRepository();
     
        public string HomeTeamName
        {
            get
            {
                return teams.GetTeams().Where(t => t.TeamId == this.HomeTeamId).FirstOrDefault().TeamName;
            }
        }
        public string AwayTeamName
        {
            get
            {
                return teams.GetTeams().Where(t => t.TeamId == this.AwayTeamId).FirstOrDefault().TeamName;
            }
        }
    }
}