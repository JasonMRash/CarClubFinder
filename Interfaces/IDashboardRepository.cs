using CarClubWebApp.Models;

namespace CarClubWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<Competition>> GetAllUserCompetitions();

        Task<IEnumerable<Club>> GetAllUserClubs();
    }
}
