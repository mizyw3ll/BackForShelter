namespace AnimalShelter.Models.DTO.Dictionary.AnimalBreed
{
    public class AnimalBreedRequest
    {
        public Guid AnimalViewId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
