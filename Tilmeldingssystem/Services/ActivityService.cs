using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;  // Assuming you have DTOs defined

namespace Tilmeldingssystem.Services
{
    public class ActivityService : IActivityService
    {
        private readonly TilmeldingsDbContext _context;

        public ActivityService(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public async Task<MemberActivityRegistrationResultDto?> RegisterMemberToActivityAsync(MemberActivityRegistrationDto dto)
        {
            var member = await _context.Members.FindAsync(dto.MemberId);
            var activity = await _context.Activities.FindAsync(dto.ActivityId);

            if (member == null || activity == null)
                return null;  // Or throw an exception or return a failure DTO/message

            var alreadyRegistered = await _context.Set<MemberActivity>()
                .AnyAsync(ma => ma.MemberId == dto.MemberId && ma.ActivityId == dto.ActivityId);

            if (alreadyRegistered)
                return null;  // Or throw, or return a failure DTO/message

            var memberActivity = new MemberActivity
            {
                MemberId = dto.MemberId,
                ActivityId = dto.ActivityId
            };

            _context.Add(memberActivity);
            await _context.SaveChangesAsync();

            return new MemberActivityRegistrationResultDto
            {
                ActivityName = activity.Name,
                Location = activity.Location,
                Time = activity.StartTime,
                Amount = activity.Price,
                MemberName = member.FullName
            };
        }


    }
}
