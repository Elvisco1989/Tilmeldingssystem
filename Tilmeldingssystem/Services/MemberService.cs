using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    /// <summary>
    /// Service for handling member-related operations such as registering members to clubs.
    /// </summary>
    public class MemberService : IMemberService
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public MemberService(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Registers a member to a club asynchronously.
        /// Checks if member and club exist, and prevents duplicate registrations.
        /// </summary>
        /// <param name="dto">The registration data transfer object containing member and club IDs.</param>
        /// <returns>A message indicating the registration result.</returns>
        public async Task<string> RegisterMemberToClubAsync(MemberClubRegistrationDto dto)
        {
            // Find member by ID
            var member = await _context.Members.FindAsync(dto.MemberId);
            // Find club by ID
            var club = await _context.Clubs.FindAsync(dto.ClubId);

            // Return error if either member or club does not exist
            if (member == null || club == null)
                return "Member or Club not found.";

            // Check if member is already registered in the club
            var exists = await _context.Set<MemberClub>()
                .AnyAsync(mc => mc.MemberId == dto.MemberId && mc.ClubId == dto.ClubId);

            if (exists)
                return "Member is already registered in this club.";

            // Create new member-club registration
            var memberClub = new MemberClub
            {
                MemberId = dto.MemberId,
                ClubId = dto.ClubId
            };

            // Add to context and save changes
            _context.Add(memberClub);
            await _context.SaveChangesAsync();

            return "Member successfully registered to the club.";
        }
    }
}
