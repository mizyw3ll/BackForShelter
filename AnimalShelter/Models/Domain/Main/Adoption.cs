using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Main
{
    public class Adoption
    {
        //private Adoption(Guid id, Guid animalId, Guid adopterId, Guid employeeId, DateOnly adoptionDate, string contractNumber)
        //{
        //    Id = id;
        //    AnimalId = animalId;
        //    AdopterId = adopterId;
        //    EmployeeId = employeeId;
        //    AdoptionDate = adoptionDate;
        //    ContractNumber = contractNumber;
        //}

        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly AdoptionDate { get; set; }
        public bool IsAdoption { get; set; }
        public string ContractNumber { get; set; } = string.Empty;
        public Guid AdoptionApplicationId { get; set; }


        //ключи
        public Employee Employee { get; set; }
        public AdoptionApplication AdoptionApplication { get; set; }


        //public static (Adoption Adoption, string Error) Create(
        //    Guid id,
        //    Guid animalId,
        //    Guid adopterId,
        //    Guid employeeId,
        //    DateOnly adoptionDate,
        //    string contractNumber
        //    )
        //{
        //    // нужно добавить вывод на ошибки
        //    var error = string.Empty;

        //    var adoption = new Adoption(id, animalId, adopterId, employeeId, adoptionDate, contractNumber);

        //    return (adoption, error);
        //}
    }
}
