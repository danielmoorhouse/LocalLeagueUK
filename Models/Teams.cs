using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Teams")]
    public class Teams
    {
        DBContext db = new DBContext();
        [Key]
        [Column("TeamId")]
        public int TeamId { get; set; }

        [Column("LeagueId")]
        public int LeagueId { get; set; }

        [Column("ClubId")]
        public int ClubId { get; set; }

        [Column("TeamName")]
        public string TeamName { get; set; }

        [Column("Coach1")]
        public string Coach1 { get; set; }

        [Column("Coach2")]
        public string Coach2 { get; set; }

        [Column("Coach3")]
        public string Coach3 { get; set; }

        
    }
  
}