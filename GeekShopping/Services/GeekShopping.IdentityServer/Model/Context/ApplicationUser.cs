using Microsoft.AspnetCore.Identity;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class ApplicationUser : IdentityUser
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}