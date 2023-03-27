using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarClubWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userClubs = _context.Clubs.Where(c => c.AppUser.Id == curUser.ToString());
            return userClubs.ToList();
        }

        public async Task<List<Competition>> GetAllUserCompetitions()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userCompetitions = _context.Competitions.Where(c => c.AppUser.Id == curUser.ToString());
            return userCompetitions.ToList();
        }

    }
}
