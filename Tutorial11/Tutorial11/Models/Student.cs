using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tutorial11.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Address or Link For Avatar is Required")]
        public string Avatar { get; set; }
        [Required(ErrorMessage ="FirstName is Required ")]
        [MaxLength(50,ErrorMessage ="Max length is 50")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of birth is Required")]
        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Studies info is Required")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Studies { get; set; }
    }
}
