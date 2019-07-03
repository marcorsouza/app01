using System;
namespace App01.Model.Application.Api.Models
{
    public class NewUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }

        public string AuthenticationUserName { get; set; }
        public string AuthenticationPassword { get; set; }

        public DateTime BirthDate {get;set;}
    }

    public class UserViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Cpf {get;set;}
    }
}