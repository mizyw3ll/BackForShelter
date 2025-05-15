namespace AnimalShelter.Models.DTO.Main.AdoptionApplication
{
    public class AdoptionApplicationRequest
    {
        public Guid AnimalId { get; set; }
        public Guid UserId { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public string LivingConditions { get; set; } = string.Empty;
        public Guid AppStatusId { get; set; }
    }
}
