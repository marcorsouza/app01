using App01.Model.Domain.Entities;
using MediatR;
using System;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class CreateUserCommand : ICreateCommand<User>
    {
        public CreateUserCommand()
        {
        }
    
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }

        public string AuthenticationUserName { get; set; }
        public string AuthenticationPassword { get; set; }

        public DateTime BirthDate { get; set; }
    }
}