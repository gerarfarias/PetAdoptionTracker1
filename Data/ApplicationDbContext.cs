using Microsoft.EntityFrameworkCore;
using PetAdoptionTracker.Models;

namespace PetAdoptionTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
