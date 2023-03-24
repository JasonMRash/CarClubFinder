﻿using CarClubWebApp.Data.Enum;
using CarClubWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarClubWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public string Website { get; set; }

        public IFormFile Image { get; set; }

        public ClubCategory ClubCategory { get; set; }
    }
}
