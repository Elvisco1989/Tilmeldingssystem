using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetAllClubs();
        Club GetClubById(int id);
        void AddClub(Club club);
        void UpdateClub(Club club);
        void DeleteClub(int id);
        bool SaveChanges();
    }
}
