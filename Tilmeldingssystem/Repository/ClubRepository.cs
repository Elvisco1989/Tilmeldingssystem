using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    /// <summary>
    /// Repository class for managing Club entities in the database.
    /// Implements CRUD operations and retrieval of clubs with their members.
    /// </summary>
    public class ClubRepository : IClubRepository
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public ClubRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new club to the database context (changes not saved immediately).
        /// </summary>
        /// <param name="club">Club entity to add</param>
        public void AddClub(Club club)
        {
            _context.Clubs.Add(club);
        }

        /// <summary>
        /// Deletes a club by id from the database context (changes not saved immediately).
        /// </summary>
        /// <param name="id">Club id</param>
        public void DeleteClub(int id)
        {
            var club = GetClubById(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
            }
        }

        /// <summary>
        /// Retrieves all clubs from the database.
        /// </summary>
        /// <returns>List of all clubs</returns>
        public IEnumerable<Club> GetAllClubs()
        {
            return _context.Clubs.ToList();
        }

        /// <summary>
        /// Retrieves a club by its id.
        /// </summary>
        /// <param name="id">Club id</param>
        /// <returns>Club entity or null if not found</returns>
        public Club? GetClubById(int id)
        {
            return _context.Clubs.FirstOrDefault(c => c.ClubId == id);
        }

        /// <summary>
        /// Saves all pending changes in the database context.
        /// </summary>
        /// <returns>True if one or more changes were saved</returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Updates an existing club in the database context (changes not saved immediately).
        /// </summary>
        /// <param name="club">Club entity with updated values</param>
        public void UpdateClub(Club club)
        {
            _context.Clubs.Update(club);
        }

        /// <summary>
        /// Retrieves all clubs including their related members via MemberClubs join entity.
        /// Uses eager loading to include related data.
        /// </summary>
        /// <returns>List of clubs with their members</returns>
        public IEnumerable<Club> GetAllClubsWithMembers()
        {
            return _context.Clubs
                .Include(c => c.MemberClubs)
                    .ThenInclude(mc => mc.Member)
                .AsNoTracking()  // Improves performance for read-only queries
                .ToList();
        }
    }
}
