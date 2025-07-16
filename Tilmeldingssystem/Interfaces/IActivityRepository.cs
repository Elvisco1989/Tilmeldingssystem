using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    /// <summary>
    /// Repository interface for managing Activity entities.
    /// Provides methods to retrieve, add, update, delete activities and persist changes.
    /// </summary>
    public interface IActivityRepository
    {
        /// <summary>
        /// Retrieves all activities.
        /// </summary>
        /// <returns>An enumerable collection of Activity objects.</returns>
        IEnumerable<Activity> GetAllActivities();

        /// <summary>
        /// Retrieves a specific activity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the activity.</param>
        /// <returns>The Activity object if found; otherwise, null.</returns>
        Activity? GetActivityById(int id);

        /// <summary>
        /// Adds a new activity to the repository.
        /// </summary>
        /// <param name="activity">The Activity object to add.</param>
        void AddActivity(Activity activity);

        /// <summary>
        /// Updates an existing activity.
        /// </summary>
        /// <param name="activity">The Activity object with updated values.</param>
        void UpdateActivity(Activity activity);

        /// <summary>
        /// Deletes an activity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the activity to delete.</param>
        void DeleteActivity(int id);

        /// <summary>
        /// Persists changes made to the repository.
        /// </summary>
        /// <returns>True if changes were saved successfully; otherwise, false.</returns>
        bool SaveChanges();
    }
}
