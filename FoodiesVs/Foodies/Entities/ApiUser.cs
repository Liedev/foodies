using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Entities
{
    public class ApiUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
