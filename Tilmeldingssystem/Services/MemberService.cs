using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly TilmeldingsDbContext _context;

        public MemberService(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterMemberToClubAsync(MemberClubRegistrationDto dto)
        {
            var member = await _context.Members.FindAsync(dto.MemberId);
            var club = await _context.Clubs.FindAsync(dto.ClubId);

            if (member == null || club == null)
                return "Member or Club not found.";

            var exists = await _context.Set<MemberClub>()
                .AnyAsync(mc => mc.MemberId == dto.MemberId && mc.ClubId == dto.ClubId);

            if (exists)
                return "Member is already registered in this club.";

            var memberClub = new MemberClub
            {
                MemberId = dto.MemberId,
                ClubId = dto.ClubId
            };

            _context.Add(memberClub);
            await _context.SaveChangesAsync();

            return "Member successfully registered to the club.";
        }
    }
}
