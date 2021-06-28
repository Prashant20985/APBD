using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "BirthDate is Required")]
        public DateTime BirthDate { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}
