using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Dictionary
{
    public class EmployeePost
    {
        //private EmployeePost(Guid id, string title)
        //{
        //    Id = id;
        //    Title = title;
        //}

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        //public static (EmployeePost EmployeePost, string Error) Create(Guid id, string title)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > 250)
        //        error = "Название пустое либо превышает 250 символов";

        //    var employeePost = new EmployeePost(id, title);

        //    return (employeePost, error);
        //}
    }
}
