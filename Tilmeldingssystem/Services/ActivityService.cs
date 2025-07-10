using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;  // Assuming you have DTOs defined

namespace Tilmeldingssystem.Services
{
    public class ActivityService : IActivityService
    {
        private readonly TilmeldingsDbContext _context;
        private readonly PaymentService _paymentService;

        public ActivityService(TilmeldingsDbContext context, PaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;
        }

        public async Task<MemberActivityRegistrationResultDto?> RegisterMemberToActivityAsync(MemberActivityRegistrationDto dto)
        {
            var member = await _context.Members.FindAsync(dto.MemberId);
            var activity = await _context.Activities.FindAsync(dto.ActivityId);

            if (member == null || activity == null)
                return null;

            var alreadyRegistered = await _context.Set<MemberActivity>()
                .AnyAsync(ma => ma.MemberId == dto.MemberId && ma.ActivityId == dto.ActivityId);

            if (alreadyRegistered)
                return null;

            var memberActivity = new MemberActivity
            {
                MemberId = dto.MemberId,
                ActivityId = dto.ActivityId
            };

            _context.MemberActivities.Add(memberActivity);
            await _context.SaveChangesAsync();

            // Create Stripe PaymentIntent
            var intent = _paymentService.CreateActivityPaymentIntent(memberActivity);

            return new MemberActivityRegistrationResultDto
            {
                ActivityName = activity.Name,
                Location = activity.Location,
                Time = activity.StartTime,
                Amount = activity.Price,
                MemberName = member.FullName,
                PaymentIntentClientSecret = intent.ClientSecret
            };
        }
    }


}

