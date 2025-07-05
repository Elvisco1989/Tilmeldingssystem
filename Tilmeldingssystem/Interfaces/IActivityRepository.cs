using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAllActivities();
        Activity GetActivityById(int id);
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void DeleteActivity(int id);
        bool SaveChanges();
    }
}
