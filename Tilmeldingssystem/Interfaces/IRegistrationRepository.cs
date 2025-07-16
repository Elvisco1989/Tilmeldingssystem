using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    /// <summary>
    /// Repository interface for managing Registration entities.
    /// Defines methods to retrieve, add, update, delete registrations,
    /// and persist changes to the data store.
    /// </summary>
    public interface IRegistrationRepository
    {
        /// <summary>
        /// Retrieves all registrations.
        /// </summary>
        /// <returns>An enumerable collection of Registration objects.</returns>
        IEnumerable<Registration> GetAllRegistrations();

        /// <summary>
        /// Retrieves a registration by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the registration.</param>
        /// <returns>The Registration object if found; otherwise, null.</returns>
        Registration? GetRegistrationById(int id);

        /// <summary>
        /// Adds a new registration to the repository.
        /// </summary>
        /// <param name="registration">The Registration object to add.</param>
        void AddRegistration(Registration registration);

        /// <summary>
        /// Updates an existing registration.
        /// </summary>
        /// <param name="registration">The Registration object with updated information.</param>
        void UpdateRegistration(Registration registration);

        /// <summary>
        /// Deletes a registration by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the registration to delete.</param>
        void DeleteRegistration(int id);

        /// <summary>
        /// Saves all pending changes to the data store.
        /// </summary>
        /// <returns>True if the save operation was successful; otherwise, false.</returns>
        bool SaveChanges();
    }
}
