using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionTracker.Models;
using PetAdoptionTracker.Services;

namespace PetAdoptionTracker.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            var pets = await _petService.GetAllPetsAsync();
            return View(pets);
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null)
                return NotFound();

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,Age,HealthStatus,IsAdopted")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                await _petService.AddPetAsync(pet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null)
                return NotFound();

            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,Age,HealthStatus,IsAdopted")] Pet pet)
        {
            if (id != pet.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _petService.UpdatePetAsync(pet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null)
                return NotFound();

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _petService.DeletePetAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
