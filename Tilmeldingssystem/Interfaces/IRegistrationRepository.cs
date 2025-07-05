using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    public interface IRegistrationRepository
    {
        IEnumerable<Registration> GetAllRegistrations();
        Registration GetRegistrationById(int id);
        void AddRegistration(Registration registration);
        void UpdateRegistration(Registration registration);
        void DeleteRegistration(int id);
        bool SaveChanges();
    }
}
