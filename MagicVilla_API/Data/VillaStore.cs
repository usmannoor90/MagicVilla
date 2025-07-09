using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villasList = new List<VillaDTO>()
        {
                new VillaDTO() { Id = 1, Name = "usman",OccuPancy=4,Sqft=45 },
                new VillaDTO() { Id = 2, Name = "Noor",OccuPancy=8,Sqft=85 }
            };
    }
}
