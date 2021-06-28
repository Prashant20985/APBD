using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.DTOs.Response
{
    public class GetListOfPrescriptionDto
    {
        public int IdPrescription { get; set; }
        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }
        public object Doctor { get; set; }
        public object Patient { get; set; }
        public object Medicament { get; set; }
    }
}
