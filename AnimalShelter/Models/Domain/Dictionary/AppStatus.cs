using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Dictionary
{
    public class AppStatus
    {
        //private AppStatus(Guid id, string title)
        //{
        //    Id = id;
        //    Title = title;
        //}

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        //public static (AppStatus AppStatus, string Error) Create(Guid id, string title)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > 250)
        //        error = "Название пустое либо превышает 250 символов";

        //    var appStatus = new AppStatus(id, title);

        //    return (appStatus, error);
        //}
    }
}
