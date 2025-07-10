using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Tilmeldingssystem.AppDbcontext
{
    public class LoginDBContext : IdentityDbContext<IdentityUser>
    {
        public LoginDBContext() 
            
        {

        }

        public LoginDBContext(DbContextOptions<LoginDBContext> options) : base(options)
        {

        }
    }
}
