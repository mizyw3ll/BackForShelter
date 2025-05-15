using AnimalShelter.Models.Domain.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Domain.Main
{
    public class User
    {
        //private User(Guid id, string lastName, string firstName,
        //    string patronymic, DateOnly birthday, string address,
        //    string phone, string email, Guid passportDateId,
        //    bool isActive, string login, string password)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    Patronymic = patronymic;
        //    Birthday = birthday;
        //    Address = address;
        //    Phone = phone;
        //    Email = email;
        //    PassportDateId = passportDateId;
        //    IsActive = isActive;
        //    Login = login;
        //    Password = password;
        //}

        public Guid Id { get; set; }
        public string LastName {  get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public Guid RoleUserId { get; set; }

        public RoleUser RoleUser { get; set; }


        //public static (User User, string Error) Create(
        //    Guid id, string lastName, string firstName,
        //    string patronymic, DateOnly birthday, string address,
        //    string phone, string email, Guid passportDateId,
        //    bool isActive, string login, string password)
        //{
        //    var error = string.Empty;

        //    if(string.IsNullOrEmpty(lastName) || 
        //       string.IsNullOrEmpty(firstName) ||
        //       string.IsNullOrEmpty(address) ||
        //       string.IsNullOrEmpty(phone) ||
        //       string.IsNullOrEmpty(email) ||
        //       string.IsNullOrEmpty(login) ||
        //       string.IsNullOrEmpty(password))
        //        error = "Укажите корректные данные для пользователя!";

        //    var user = new User(id, lastName, firstName,
        //        patronymic, birthday, address,
        //        phone, email, passportDateId,
        //        isActive, login, password);

        //    return (user, error);
        //}

    }
}
