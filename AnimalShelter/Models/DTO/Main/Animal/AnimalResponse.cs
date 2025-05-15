using AnimalShelter.Models.Domain.Dictionary;

namespace AnimalShelter.Models.DTO.Main.Animal
{
    public class AnimalResponse
    {
        public Guid Id { get; set; }
        public Guid AnimalViewId { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public Guid AnimalBreedId { get; set; }
        public string DistinctiveFeatures { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Photos { get; set; } = string.Empty;
        public Guid AnimalStatusId { get; set; }
    }
}
