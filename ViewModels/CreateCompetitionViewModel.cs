using CarClubWebApp.Data.Enum;
using CarClubWebApp.Models;

namespace CarClubWebApp.ViewModels
{
    public class CreateCompetitionViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public IFormFile Image { get; set; }

        public CompetitionCategory CompetitionCategory { get; set; }
    }
}
