using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.Models.Authentication
{
    public class RegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
