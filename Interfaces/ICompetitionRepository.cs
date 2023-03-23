using CarClubWebApp.Models;

namespace CarClubWebApp.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> GetAll();
        Task<Competition> GetByIdAsync(int id);
        Task<IEnumerable<Competition>> GetAllCompetitionsByCity(string city);

        bool Add(Competition competition);

        bool Update(Competition competition);

        bool Delete(Competition competition);

        bool Save();
    }
}
