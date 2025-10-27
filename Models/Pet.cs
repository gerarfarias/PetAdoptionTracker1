using System.ComponentModel.DataAnnotations;

namespace PetAdoptionTracker.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Species { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Display(Name = "Health Status")]
        public string? HealthStatus { get; set; }

        [Display(Name = "Is Adopted?")]
        public bool IsAdopted { get; set; } = false;
    }
}
