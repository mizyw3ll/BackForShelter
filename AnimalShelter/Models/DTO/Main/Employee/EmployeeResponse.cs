namespace AnimalShelter.Models.DTO.Main.Employee
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EmployeePostId { get; set; }
        public DateOnly HireDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
