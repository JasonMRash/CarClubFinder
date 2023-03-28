namespace CarClubWebApp.ViewModels
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public string? Car { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public IFormFile Image { get; set; }
    }
}

