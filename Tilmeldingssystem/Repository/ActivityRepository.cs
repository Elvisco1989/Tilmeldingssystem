using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly TilmeldingsDbContext _context;

        public ActivityRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        public void AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            //_context.SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            var activity = GetActivityById(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }

        public Activity? GetActivityById(int id)
        {
            return _context.Activities.FirstOrDefault(a => a.ActivityId == id);
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }
    }
}
