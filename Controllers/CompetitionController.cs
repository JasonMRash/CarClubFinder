﻿using CarClubWebApp.Data;
using CarClubWebApp.Interfaces;
using CarClubWebApp.Models;
using CarClubWebApp.Repository;
using CarClubWebApp.Services;
using CarClubWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarClubWebApp.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompetitionController(ICompetitionRepository competitionRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _competitionRepository = competitionRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createCompetitionViewModel = new CreateCompetitionViewModel
            {
                AppUserId = curUserId,
            };
            return View(createCompetitionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateCompetitionViewModel competitionVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(competitionVM.Image);
                var competition = new Competition
                {
                    Title = competitionVM.Title,
                    Description = competitionVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = competitionVM.AppUserId,
                    Address = new Address
                    {
                        Street = competitionVM.Address.Street,
                        City = competitionVM.Address.City,
                        State = competitionVM.Address.State,
                    }
                };
                _competitionRepository.Add(competition);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(competitionVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var club = await _competitionRepository.GetByIdAsync(id);
            if (club == null)
            {
                return View("Error");
            }
            var clubVM = new EditCompetitionViewModel
            {
                Id  = id,
                Title = club.Title,
                Description = club.Description,
                AddressId = club.AddressId,
                Address = club.Address,
                URL = club.Image,
                CompetitionCategory = club.CompetitionCategory,
            };
            return View(clubVM);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, EditCompetitionViewModel competitionVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit competition");
                return View("Edit", competitionVM);
            }

            var userClub = await _competitionRepository.GetByIdAsync(id);

            if (userClub != null)
            {
                if (userClub.Image!= null)
                {
                    try
                    {
                        var fi = new FileInfo(userClub.Image);
                        var publicId = Path.GetFileNameWithoutExtension(fi.Name);
                        await _photoService.DeletePhotoAsync(publicId);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View(competitionVM);
                    }
                }

                var photoResult = await _photoService.AddPhotoAsync(competitionVM.Image);


                userClub.Title = competitionVM.Title;
                userClub.Description = competitionVM.Description;
                userClub.Image = photoResult.Url.ToString();
                userClub.AddressId = competitionVM.AddressId;
                userClub.Address = new Address
                {
                    Street = competitionVM.Address.Street,
                    City = competitionVM.Address.City,
                    State = competitionVM.Address.State,
                };

                _competitionRepository.Update(userClub);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to edit competition");
                return View("Edit", competitionVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var competition = await _competitionRepository.GetByIdAsync(id);
            if (competition == null)
            {
                return View("Error");
            }

            return View(competition);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var competition = await _competitionRepository.GetByIdAsync(id);
            if (competition == null)
            {
                return View("Error");
            }
            _competitionRepository.Delete(competition);
            return RedirectToAction("Index");
        }
    }
}
