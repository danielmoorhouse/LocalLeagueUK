using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Leagues> Leagues { get; set; }

        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<LeagueOps> LeagueOps { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Venues> Venues { get; set; }
     }
}