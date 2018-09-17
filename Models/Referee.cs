using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    [Table("Referees")]
    public class Referee
    {
        [Key]
        [Column("RefId")]
        public int RefId { get; set; }

        [Column("RefName")]
        public string RefName { get; set; }
    }
}