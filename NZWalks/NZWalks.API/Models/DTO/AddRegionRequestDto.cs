using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "Code must be minimum of three characters")]
        [MaxLength(3, ErrorMessage = "Code must be maximum of three characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name must be maximum of fifty characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
