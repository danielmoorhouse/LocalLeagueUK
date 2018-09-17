using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Clubs")]
    public class Clubs
    {
        [Key]
        [Column("ClubId")]
        public int ClubId { get; set; }

        [Column("ClubName")]
        public string ClubName { get; set; }

        [Column("ClubAddress1")]
        public string ClubAddress1 { get; set; }

        [Column("ClubAddress2")]
        public string ClubAddress2 { get; set; }

        [Column("PostCode")]
        public string PostCode { get; set; }

        [Column("ClubLogoUrl")]
        public string ClubLogoUrl { get; set; }
    }
}