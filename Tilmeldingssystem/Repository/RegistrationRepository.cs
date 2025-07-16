using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    /// <summary>
    /// Repository class for managing Registration entities in the database.
    /// Implements CRUD operations and persists changes.
    /// </summary>
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public RegistrationRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new registration and immediately saves changes to the database.
        /// </summary>
        /// <param name="registration">Registration entity to add</param>
        public void AddRegistration(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a registration by id and immediately saves changes if found.
        /// </summary>
        /// <param name="id">Registration id</param>
        public void DeleteRegistration(int id)
        {
            var registration = GetRegistrationById(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all registrations from the database.
        /// </summary>
        /// <returns>List of all registrations</returns>
        public IEnumerable<Registration> GetAllRegistrations()
        {
            return _context.Registrations.ToList();
        }

        /// <summary>
        /// Retrieves a registration by its id.
        /// </summary>
        /// <param name="id">Registration id</param>
        /// <returns>Registration entity or null if not found</returns>
        public Registration? GetRegistrationById(int id)
        {
            return _context.Registrations.FirstOrDefault(r => r.RegistrationId == id);
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
        /// Updates an existing registration and immediately saves changes to the database.
        /// </summary>
        /// <param name="registration">Registration entity with updated values</param>
        public void UpdateRegistration(Registration registration)
        {
            _context.Registrations.Update(registration);
            _context.SaveChanges();
        }
    }
}
