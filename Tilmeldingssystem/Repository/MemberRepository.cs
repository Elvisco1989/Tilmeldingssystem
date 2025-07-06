using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TilmeldingsDbContext _context;

        public MemberRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
        }

        public void DeleteMember(int id)
        {
            var member = GetMemberById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(m => m.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateMember(Member member)
        {
            _context.Members.Update(member);
        }
    }
}
