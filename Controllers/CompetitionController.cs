using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarClubWebApp.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionController(ApplicationDbContext context, ICompetitionRepository competitionRepository)
        {
            _context = context;
            _competitionRepository = competitionRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Competition> competitions = await _competitionRepository.GetAll();
            return View(competitions);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Competition competition = await _competitionRepository.GetByIdAsync(id);
            return View(competition);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Competition competition)
        {
            if (!ModelState.IsValid)
            { 
                return View(competition);
            }
            _competitionRepository.Add(competition);
            return RedirectToAction("Index");
        }
    }
}
