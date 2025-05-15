namespace AnimalShelter.Models.DTO.Main.Adoption
{
    public class AdoptionRequest
    {
        public Guid EmployeeId { get; set; }
        public DateOnly AdoptionDate { get; set; }
        public bool IsAdoption { get; set; }
        public string ContractNumber { get; set; } = string.Empty;
        public Guid AdoptionApplicationId { get; set; }
    }
}
