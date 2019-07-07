using App01.Model.Domain.Entities;
using App01.Model.Infra.CrossCutting.Features.Commands;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class DeleteUserCommand : IDeleteCommand<User, int> {
        public DeleteUserCommand () { }

        public int Id { get; set; }
    }

}