using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.Dto
{
    public class VillaNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        [Required]
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;

    }
}
