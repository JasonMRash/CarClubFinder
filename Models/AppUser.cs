using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarClubWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public string? Car { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [ForeignKey("Address")]

        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public ICollection<Competition> Competitions { get; set; }
    }
}
