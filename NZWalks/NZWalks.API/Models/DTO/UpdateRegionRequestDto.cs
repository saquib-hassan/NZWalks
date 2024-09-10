using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code must be minimum of three characters long")]
        [MaxLength(3,ErrorMessage ="Code must be maximum of three characters long")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name must be maximum of fifty characters long")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
