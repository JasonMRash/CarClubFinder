using CarClubWebApp.Data;
using CarClubWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarClubWebApp.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetitionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Competition> competitions = _context.Competitions.ToList();
            return View(competitions);
        }
    }
}
