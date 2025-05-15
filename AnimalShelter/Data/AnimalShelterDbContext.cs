using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.Domain.Main;

namespace AnimalShelter.Data
{
    public class AnimalShelterDbContext : DbContext
    {
        public AnimalShelterDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        // словари

        public DbSet<AnimalBreed> AnimalBreeds { get; set; }
        public DbSet<AnimalStatus> AnimalStatuses { get; set; }
        public DbSet<AnimalView> AnimalViews { get; set; }
        public DbSet<AppStatus> AppStatuses { get; set; }
        public DbSet<EmployeePost> EmployeePosts { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

        // Главные

        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AdoptionApplication> AdoptionalApplications { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<TemporaryPlacement> TemporaryPlacement { get; set; }
    }
}
