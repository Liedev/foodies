using Foodies.Models;
using Microsoft.AspNetCore.Identity;

namespace Foodies.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public EndUser EndUser { get; set; }
    }
}
