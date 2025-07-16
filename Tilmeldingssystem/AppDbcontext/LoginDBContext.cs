using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Tilmeldingssystem.AppDbcontext
{
    /// <summary>
    /// Represents the Entity Framework Core database context for handling user authentication and identity management.
    /// Inherits from IdentityDbContext to integrate ASP.NET Core Identity functionality using the IdentityUser class.
    /// Provides constructors for default initialization and dependency injection with DbContext options.
    /// </summary>
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
