using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial5.Models
{
    public class WareHouse
    {
        [Required(ErrorMessage ="IdProduct is required")]
        [Range(1,10000,ErrorMessage ="Value Should Be More Than 0")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "IdWareHouse is required")]
        [Range(1, 10000, ErrorMessage = "Value Should Be More Than 0")]
        public int IdWarehouse { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1.0, 9999.99, ErrorMessage = "Value Should Be More Than 0.0")]
        public double Amount { get; set; }

        [Required(ErrorMessage ="Create Date is Required")]
        public DateTime CreatedAt { get; set; }
    }
}
