using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dto
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public int SqFt { get; set; }
        [Required]
        public double rate { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Amenity { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }= DateTime.Now;
    }
}
