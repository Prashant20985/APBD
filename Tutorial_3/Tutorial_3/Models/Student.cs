using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_3.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Index { get; set; }
        public DateTime Birthdate { get; set; }
        public string Study { get; set; }
        public string Mode { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
