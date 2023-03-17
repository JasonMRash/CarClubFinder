using System.ComponentModel.DataAnnotations;

namespace CarClubWebApp.Models
{
    public class AppUser
    {
        [Key]

        public string Id { get; set; }

        public int? Car { get; set; }

        public Address? Address { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public ICollection<Competition> Competitions { get; set; }
    }
}
