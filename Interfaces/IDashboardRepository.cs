using CarClubWebApp.Models;

namespace CarClubWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Competition>> GetAllUserCompetitions();

        Task<List<Club>> GetAllUserClubs();
    }
}
