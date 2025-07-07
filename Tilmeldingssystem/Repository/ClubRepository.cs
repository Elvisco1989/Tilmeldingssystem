using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly TilmeldingsDbContext _context;

        public ClubRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public void AddClub(Club club)
        {
            _context.Clubs.Add(club);
        }

        public void DeleteClub(int id)
        {
            var club = GetClubById(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
            }
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return _context.Clubs.ToList();
        }

        public Club? GetClubById(int id)
        {
            return _context.Clubs.FirstOrDefault(c => c.ClubId == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateClub(Club club)
        {
            _context.Clubs.Update(club);
        }

        public IEnumerable<Club> GetAllClubsWithMembers()
        {
            return _context.Clubs
                .Include(c => c.MemberClubs)
                    .ThenInclude(mc => mc.Member)
                .AsNoTracking()  // Optional: improves read-only performance
                .ToList();
        }

    }
}
