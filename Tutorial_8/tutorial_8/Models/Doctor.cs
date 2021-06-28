using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(100)]
        public string Email { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}
