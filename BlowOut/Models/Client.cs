using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Enter a first name")]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name")]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Enter an address")]
        [DisplayName("Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Enter a city")]
        public String City { get; set; }

        [Required(ErrorMessage = "Enter a state")]
        public String State { get; set; }

        [MaxLength(5), MinLength(5)]
        [Required(ErrorMessage = "Enter a zip")]
        public String Zip { get; set; }

        [Required(ErrorMessage = "Enter an email")]
        [EmailAddress]
        public String Email { get; set; }

        [Required()]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Phone]
        public String Phone { get; set; }


    }
}