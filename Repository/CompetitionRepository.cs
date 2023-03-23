using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarClubWebApp.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CompetitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Competition competition)
        {
            _context.Add(competition);
            return Save();
        }

        public bool Update(Competition competition)
        { 
            _context.Update(competition);
            return Save();
        }

        public bool Delete(Competition competition)
        {
            _context.Remove(competition);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public async Task<IEnumerable<Competition>> GetAll()
        {
            return await _context.Competitions.ToListAsync();
        }

        public async Task<Competition> GetByIdAsync(int id)
        {
            return await _context.Competitions.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsByCity(string city)
        {
            return await _context.Competitions.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }
    }
}
