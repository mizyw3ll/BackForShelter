namespace AnimalShelter.Models.DTO.Main.TemporaryPlacement
{
    public class TemporaryPlacementRequest
    {
        public Guid VoluenteerId { get; set; }
        public Guid AnimalId { get; set; }
        public DateOnly DateAnimalTake { get; set; }
        public DateOnly DateAnimalReturn { get; set; }
    }
}
