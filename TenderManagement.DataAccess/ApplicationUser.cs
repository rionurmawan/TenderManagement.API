using Microsoft.AspNetCore.Identity;

namespace TenderManagement.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
