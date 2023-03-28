using CarClubWebApp.Models;

namespace CarClubWebApp.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();

        Task<AppUser> GetUserById(string id);

        Task<IEnumerable<Competition>> GetAllUserCompetitions(string id);

        Task<IEnumerable<Club>> GetAllUserClubs(string id);

        bool Add(AppUser user);

        bool Update(AppUser user);

        bool Delete(AppUser user);

        bool Save();
    }
}
