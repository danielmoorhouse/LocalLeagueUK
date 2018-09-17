using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public partial class Players
    {
        TeamsRepository teams = new TeamsRepository();

        public string PlayerTeamName
        {
            get
            {
                return teams.GetTeams().Where(t => t.TeamId == this.TeamId).FirstOrDefault().TeamName;
            }
        }
    }
}