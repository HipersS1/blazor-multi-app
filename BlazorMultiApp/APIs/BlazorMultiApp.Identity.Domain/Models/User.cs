using Microsoft.AspNetCore.Identity;

namespace BlazorMultiApp.Identity.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
    }
}
