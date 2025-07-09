using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int OccuPancy { get; set; }

        public int Sqft { get; set; }

    }
}
