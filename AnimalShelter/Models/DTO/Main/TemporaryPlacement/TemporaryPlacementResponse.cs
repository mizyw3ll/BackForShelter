namespace AnimalShelter.Models.DTO.Main.TemporaryPlacement
{
    public class TemporaryPlacementResponse
    {
        public Guid Id { get; set; }
        public Guid VoluenteerId { get; set; }
        public Guid AnimalId { get; set; }
        public DateOnly DateAnimalTake { get; set; }
        public DateOnly DateAnimalReturn { get; set; }
    }
}
