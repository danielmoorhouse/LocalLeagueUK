using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Leagues")]
    public class Leagues
    {
        [Key]
        [Column("LeagueId")]
        public int LeagueId { get; set; }

        [Column("LeagueOpsId")]
        public int LeagueOpsId { get; set; }

        [Column("LeagueName")]
        public string LeagueName { get; set; }
    }
}