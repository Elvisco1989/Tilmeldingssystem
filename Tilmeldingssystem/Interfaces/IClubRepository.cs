using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    /// <summary>
    /// Repository interface for managing Club entities.
    /// Provides methods to retrieve, add, update, delete clubs,
    /// retrieve clubs with their members, and persist changes.
    /// </summary>
    public interface IClubRepository
    {
        /// <summary>
        /// Retrieves all clubs.
        /// </summary>
        /// <returns>An enumerable collection of Club objects.</returns>
        IEnumerable<Club> GetAllClubs();

        /// <summary>
        /// Retrieves a specific club by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the club.</param>
        /// <returns>The Club object if found; otherwise, null.</returns>
        Club? GetClubById(int id);

        /// <summary>
        /// Adds a new club to the repository.
        /// </summary>
        /// <param name="club">The Club object to add.</param>
        void AddClub(Club club);

        /// <summary>
        /// Updates an existing club.
        /// </summary>
        /// <param name="club">The Club object with updated values.</param>
        void UpdateClub(Club club);

        /// <summary>
        /// Deletes a club by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the club to delete.</param>
        void DeleteClub(int id);

        /// <summary>
        /// Persists changes made to the repository.
        /// </summary>
        /// <returns>True if changes were saved successfully; otherwise, false.</returns>
        bool SaveChanges();

        /// <summary>
        /// Retrieves all clubs including their associated members.
        /// </summary>
        /// <returns>An enumerable collection of Club objects with their members.</returns>
        IEnumerable<Club> GetAllClubsWithMembers();
    }
}
