using App01.Model.Domain.Entities;
using System;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UpdateUserCommand : IUpdateCommand<User,int>
    {
        public UpdateUserCommand()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }
    }

}