using AnimalShelter.Models.Domain.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Main
{
    public class Employee
    {
        //private Employee(Guid id, Guid userId, Guid postId, DateOnly hireDate, bool isAdmin)
        //{
        //    Id = id;
        //    UserId = userId;
        //    PostId = postId;
        //    HireDate = hireDate;
        //    IsAdmin = isAdmin;
        //}

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EmployeePostId { get; set; }
        public DateOnly HireDate { get; set; }
        public bool IsAdmin { get; set; }


        // связи

        public User User { get; set; }
        public EmployeePost EmployeePost { get; set; }


        //public static (Employee Employee, string Error) Create(
        //    Guid id,
        //    Guid userId,
        //    Guid postId,
        //    DateOnly hireDate,
        //    bool isAdmin)
        //{
        //    var error = string.Empty;
        //    var employee = new Employee(id, userId, postId, hireDate, isAdmin);

        //    return (employee, error);
        //}

    }
}
