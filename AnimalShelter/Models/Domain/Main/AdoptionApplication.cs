using AnimalShelter.Models.Domain.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Main
{
    public class AdoptionApplication
    {
        //private AdoptionApplication(Guid id, Guid applicationId, DateOnly applicationDate, string livingConditions, Guid appStatusId)
        //{
            
        //}

        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Guid UserId { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public string LivingConditions { get; set; } = string.Empty;
        public Guid AppStatusId { get; set; }

        // связи

        public Animal Animal { get; set; }
        public User User { get; set; }
        public AppStatus AppStatus { get; set; }

        //public static (AdoptionApplication AdoptionApplication, string Error) Create (
        //    Guid id,
        //    Guid applicationId,
        //    DateOnly applicationDate,
        //    string livingConditions,
        //    Guid appStatusId
        //    )
        //{
        //    var error = string.Empty;

        //    var adoptionApplication = new AdoptionApplication(id, applicationId, applicationDate, livingConditions, appStatusId);

        //    return (adoptionApplication, error);
        //}
    }
}
