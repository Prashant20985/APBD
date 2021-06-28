using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models
{
    [Table("Prescription_Medicament")]
    public class Prescription_Medicament
    {
        /// <summary>
        /// Keys for the following table is Defined in the Prescription_MedicamentEntityTypeConfiguration.
        /// </summary>
        public int idMedicament { get; set; }
        [ForeignKey("idMedicament")]
        public Medicament Medicament { get; set; }

        public int idPrescription { get; set; }
        [ForeignKey("idPrescription")]
        public Prescription Prescription { get; set; }

        public int Dose { get; set; }

        [Required(ErrorMessage = "Details are Required")]
        [MaxLength(100)]
        public string Details { get; set; }
    }
}
