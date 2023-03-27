using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CarClubWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userCompetitions = await _dashboardRepository.GetAllUserCompetitions();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            DashboardViewModel dashboardViewModel = new DashboardViewModel()
            {
                Competitions = userCompetitions,
                Clubs = userClubs

            };
            return View(dashboardViewModel);
        }
    }
}
