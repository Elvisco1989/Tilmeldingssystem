using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    /// <summary>
    /// Repository class for managing Member entities in the database.
    /// Provides methods for CRUD operations and data persistence.
    /// </summary>
    public class MemberRepository : IMemberRepository
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public MemberRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new member to the database context (changes not saved immediately).
        /// </summary>
        /// <param name="member">Member entity to add</param>
        public void AddMember(Member member)
        {
            _context.Members.Add(member);
        }

        /// <summary>
        /// Deletes a member by id from the database context (changes not saved immediately).
        /// </summary>
        /// <param name="id">Member id</param>
        public void DeleteMember(int id)
        {
            var member = GetMemberById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
        }

        /// <summary>
        /// Retrieves all members from the database.
        /// </summary>
        /// <returns>List of all members</returns>
        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        /// <summary>
        /// Retrieves a member by its id.
        /// </summary>
        /// <param name="id">Member id</param>
        /// <returns>Member entity or null if not found</returns>
        public Member? GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(m => m.MemberId == id);
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
        /// Updates an existing member in the database context (changes not saved immediately).
        /// </summary>
        /// <param name="member">Member entity with updated values</param>
        public void UpdateMember(Member member)
        {
            _context.Members.Update(member);
        }
    }
}
