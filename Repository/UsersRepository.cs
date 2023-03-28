using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarClubWebApp.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AppUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(AppUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAllUserClubs(string id)
        {
            return await _context.Clubs.Where(c => c.AppUser.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Competition>> GetAllUserCompetitions(string id)
        {
            return await _context.Competitions.Where(c => c.AppUser.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(AppUser user)
        {
            _context.Update(user);
            return Save();
        }
    }
}
