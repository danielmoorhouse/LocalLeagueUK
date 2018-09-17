using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("LeagueOperators")]
    public class LeagueOps
    {
        [Key]
        [Column("LeagueOpsId")]
        public int LeagueOpsId { get; set; }

        [Column("LeagueOpsName")]
        public string LeagueOpsName { get; set; }

        [Column("LeagueOpsLogoUrl")]
        public string LeagueOpsLogoUrl { get; set; }
    }
}