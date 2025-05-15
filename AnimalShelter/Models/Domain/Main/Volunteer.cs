using AnimalShelter.Models.Domain.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Main
{
    public class Volunteer
    {
        //private Volunteer(Guid id, Guid userId, Guid viewHelpId, string preferences, string moreInformation)
        //{
        //    Id = id;
        //    UserId = userId;
        //    ViewHelpId = viewHelpId;
        //    Preferences = preferences;
        //    MoreInformation = moreInformation;
        //}

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Preferences { get; set; } = string.Empty;
        public string MoreInformation { get; set; } = string.Empty;

        public User User { get; set; }

        //public static (Volunteer Volunteer, string Error) Create(
        //    Guid id,
        //    Guid userId,
        //    Guid viewHelpId,
        //    string preferences,
        //    string moreInformation
        //    )
        //{
        //    var error = string.Empty;
        //    var volunteer = new Volunteer(id, userId, viewHelpId, preferences, moreInformation);

        //    return (volunteer, error);
        //}
    }
}
