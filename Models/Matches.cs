using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Matches")]
    public partial class Matches
    {
        [Key]
        [Column("MatchId")]
        public int MatchId { get; set; }

        [Column("LeagueId")]
        public int LeagueId { get; set; }
        [Column("VenueId")]
        public int VenueId { get; set; }

        [Column("RefId")]
        public int RefId { get; set; }

        [Column("HomeTeamId")]
        public int HomeTeamId { get; set; }
        

        [Column("AwayTeamId")]
        public int AwayTeamId { get; set; }
        

        [Column("HomeGoals")]
        public int HomeGoals { get; set; }

        [Column("AwayGoals")]
        public int AwayGoals { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Column("MatchDate")]
        public DateTime? MatchDate { get; set; }

   

    }
    
}