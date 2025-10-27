using System.ComponentModel.DataAnnotations;

namespace PetAdoptionTracker.Models
{
    public class Adopter
    {
        public int AdopterId { get; set; }

        [Required]
        [StringLength(60)]
        public string FullName { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Pet>? Pets { get; set; }
    }
}
