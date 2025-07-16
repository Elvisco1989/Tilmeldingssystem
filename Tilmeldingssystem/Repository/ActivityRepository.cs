using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    /// <summary>
    /// Repository class for managing Activity entities in the database.
    /// Implements CRUD operations for Activities.
    /// </summary>
    public class ActivityRepository : IActivityRepository
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public ActivityRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new activity to the database context (changes not saved immediately).
        /// </summary>
        /// <param name="activity">Activity entity to add</param>
        public void AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            // _context.SaveChanges() is not called here to allow batch saving
        }

        /// <summary>
        /// Deletes an activity by id from the database and saves changes immediately.
        /// </summary>
        /// <param name="id">Activity id</param>
        public void DeleteActivity(int id)
        {
            var activity = GetActivityById(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves an activity by its id.
        /// </summary>
        /// <param name="id">Activity id</param>
        /// <returns>Activity entity or null if not found</returns>
        public Activity? GetActivityById(int id)
        {
            return _context.Activities.FirstOrDefault(a => a.ActivityId == id);
        }

        /// <summary>
        /// Retrieves all activities from the database.
        /// </summary>
        /// <returns>List of all activities</returns>
        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
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
        /// Updates an existing activity and saves changes immediately.
        /// </summary>
        /// <param name="activity">Activity entity with updated values</param>
        public void UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }
    }
}
