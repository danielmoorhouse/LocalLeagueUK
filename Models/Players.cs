using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalLeague1.Models
{
    public partial class Players
    {
        [Key]
        [Column("PlayerId")]
        public int PlayerId { get; set; }

        [Column("PlayerName")]
        public string PlayerName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Column("Dob")]
        public DateTime? Dob { get; set; }

        [Column("TeamId")]
        public int TeamId { get; set; }

    }
}