namespace AnimalShelter.Models.DTO.Main.Voluenteer
{
    public class VolunteerRequest
    {
        public Guid UserId { get; set; }
        public string Preferences { get; set; } = string.Empty;
        public string MoreInformation { get; set; } = string.Empty;
    }
}
