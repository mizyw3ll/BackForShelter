namespace AnimalShelter.Models.DTO.Dictionary.AnimalBreed
{
    public class AnimalBreedResponse
    {
        public Guid Id { get; set; }
        public Guid AnimalViewId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
