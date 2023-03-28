using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Repository;
using CarClubWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarClubWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            var users = await _usersRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Car = user.Car,
                };
                result.Add(userViewModel);
            }

            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _usersRepository.GetUserById(id);
            var userCompetitions = await _usersRepository.GetAllUserCompetitions(id);
            var userClubs = await _usersRepository.GetAllUserClubs(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Car = user.Car,
                Competitions = userCompetitions,
                Clubs = userClubs
            };
            return View(userDetailViewModel);
        }
    }
}
