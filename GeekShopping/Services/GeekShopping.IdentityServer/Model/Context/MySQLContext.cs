using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options) { }
    }
}