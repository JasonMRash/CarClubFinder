using CarClubWebApp.Models;

namespace CarClubWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<Competition>> GetAllUserCompetitions();

        Task<IEnumerable<Club>> GetAllUserClubs();

        Task<AppUser> GetUserById(string id);

        Task<AppUser> GetUserByIdNoTracking(string id);

        bool Update(AppUser user);

        bool Save();
    }
}
