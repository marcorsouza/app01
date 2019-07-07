using System.Linq;
using App01.Model.Domain.Entities;
using App01.Model.Infra.CrossCutting.Features.Commands;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UserGetQuery : IGetQuery<User, int> {
        public IQueryable<User> Query { get; set; }
                public int Id { get; set; }
    }

}