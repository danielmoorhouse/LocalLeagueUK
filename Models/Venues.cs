using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Venues")]
    public class Venues
    {
        [Key]
        [Column("VenueId")]
        public int VenueId { get; set; }

        [Column("VenueName")]
        public string VenueName { get; set; }

        [Column("VenuePcode")]
        public string VenuePcode { get; set; }

      
    }
}