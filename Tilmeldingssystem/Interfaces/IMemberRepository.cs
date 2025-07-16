using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    /// <summary>
    /// Repository interface for managing Member entities.
    /// Provides methods to retrieve, add, update, delete members,
    /// and persist changes to the data store.
    /// </summary>
    public interface IMemberRepository
    {
        /// <summary>
        /// Retrieves all members.
        /// </summary>
        /// <returns>An enumerable collection of Member objects.</returns>
        IEnumerable<Member> GetAllMembers();

        /// <summary>
        /// Retrieves a specific member by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>The Member object if found; otherwise, null.</returns>
        Member? GetMemberById(int id);

        /// <summary>
        /// Adds a new member to the repository.
        /// </summary>
        /// <param name="member">The Member object to add.</param>
        void AddMember(Member member);

        /// <summary>
        /// Updates an existing member.
        /// </summary>
        /// <param name="member">The Member object with updated data.</param>
        void UpdateMember(Member member);

        /// <summary>
        /// Deletes a member by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the member to delete.</param>
        void DeleteMember(int id);

        /// <summary>
        /// Saves all changes made in the repository to the data store.
        /// </summary>
        /// <returns>True if changes were successfully saved; otherwise, false.</returns>
        bool SaveChanges();
    }
}
