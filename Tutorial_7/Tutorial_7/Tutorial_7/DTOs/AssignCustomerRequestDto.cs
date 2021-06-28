using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_7.DTOs
{
    public class AssignCustomerRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pesel { get; set; }
        public int IdTrip { get; set; }
        public string TripName { get; set; }
        [Column(TypeName ="Date")]
        public DateTime PaymentDate { get; set; }
    }
}
