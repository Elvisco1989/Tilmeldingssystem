using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Models.Login;
using Tilmeldingssystem.Models;

using Tilmeldingssystem.AppDbcontext;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TilmeldingsDbContext _dbContext;

        public RegisterUserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            TilmeldingsDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Password != model.ConfirmPassword)
                return BadRequest(new { error = "Password and confirmation do not match." });

            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest(new { error = "User with this email already exists." });

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            // Create Member
            var member = new Member
            {
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                DateOfBirth = model.DateOfBirth
            };

            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                message = "User registered and Member created successfully.",
                userId = user.Id,
                memberId = member.MemberId
            });
        }
    }
}
