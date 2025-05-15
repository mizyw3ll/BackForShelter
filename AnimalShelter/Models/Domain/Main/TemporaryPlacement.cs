namespace AnimalShelter.Models.Domain.Main
{
    public class TemporaryPlacement
    {
        public Guid Id { get; set; }
        public Guid VolunteerId { get; set; }
        public Guid AnimalId { get; set; }
        public DateOnly DateAnimalTake { get; set; }
        public DateOnly DateAnimalReturn { get; set; }

        public Volunteer Volunteer { get; set; }
        public Animal Animal { get; set; }
    }
}
