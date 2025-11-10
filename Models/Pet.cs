using System.ComponentModel.DataAnnotations;

namespace PetAdoptionTracker.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Species { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        public required string HealthStatus { get; set; }

        public bool IsAdopted { get; set; }
    }
}
