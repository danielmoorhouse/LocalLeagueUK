using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public class PlayersRepository
    {
        DBContext db = new DBContext();
        public List<Players> GetPlayers()
        {
            return db.Players.ToList();
        }
    }
}