using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly TilmeldingsDbContext _context;

        public RegistrationRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public void AddRegistration(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        public void DeleteRegistration(int id)
        {
            var registration = GetRegistrationById(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            return _context.Registrations.ToList();
        }

        public Registration? GetRegistrationById(int id)
        {
            return _context.Registrations.FirstOrDefault(r => r.RegistrationId == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateRegistration(Registration registration)
        {
            _context.Registrations.Update(registration);
            _context.SaveChanges();
        }
    }
}
