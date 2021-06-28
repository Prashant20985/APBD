using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models
{
    [Table("Medicament")]
    public class Medicament
    {
        [Key]
        public int idMedicament { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        [MaxLength(100)]
        public string Type { get; set; }

        public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } = new HashSet<Prescription_Medicament>();

    }
}
