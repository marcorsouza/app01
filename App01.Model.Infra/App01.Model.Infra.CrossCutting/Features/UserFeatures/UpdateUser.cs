using App01.Model.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UpdateUser : IRequest<User>
    {
        public UpdateUser()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
