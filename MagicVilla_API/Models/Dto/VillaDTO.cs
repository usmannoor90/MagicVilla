using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }

        public DateTime CreateDate { get; set; } = new DateTime();
        public DateTime UpdateDate { get; set; } = new DateTime();
        public int Sqft { get; set; }

        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}
