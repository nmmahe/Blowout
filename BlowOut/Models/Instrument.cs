using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstrumentID { get; set; }

        [Required(ErrorMessage ="Enter a description")]
        [DisplayName("Description")]
        public String Desc { get; set; }

        [Required(ErrorMessage ="Enter a type")]
        [DisplayName("Type")]
        public String Type { get; set; }

        [Required(ErrorMessage ="Enter a Price")]
        [DisplayName("Price")]
        public int Price { get; set; }

        [Display(Name = "Client ID")]
        public int? ClientID { get; set; }
        public virtual Client Client { get; set; }


    }
}