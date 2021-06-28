using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_8.DTOs.Response
{
    public class AccountResponceDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
