using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models.Authentication
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        public int IdAppUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefresHTokentExpirration { get; set; }
    }
}
