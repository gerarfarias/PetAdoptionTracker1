using PetAdoptionTracker.Data;
using PetAdoptionTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionTracker.Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllPetsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task AddPetAsync(Pet pet);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int id);
    }

    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task AddPetAsync(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            _context.Update(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
