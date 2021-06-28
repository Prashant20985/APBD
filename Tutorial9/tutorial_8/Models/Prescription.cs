using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int idPrescription { get; set; }

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Date is Required")]
        public DateTime Date { get; set; }

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "DueDate is Required")]
        public DateTime DueDate { get; set; }

        public int IdPatient { get; set; }
        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }
        public int idDoctor { get; set; }
        [ForeignKey("idDoctor")]
        public Doctor Doctor { get; set; }
 

        public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } = new HashSet<Prescription_Medicament>();

    }
}
