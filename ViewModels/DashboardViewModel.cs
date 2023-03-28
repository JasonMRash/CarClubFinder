using CarClubWebApp.Models;

namespace CarClubWebApp.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Competition> Competitions { get; set; }

        public IEnumerable<Club> Clubs { get; set; }
    }
}
