using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int SqFt { get; set; }
        public double rate { get; set; }
        public string details { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
