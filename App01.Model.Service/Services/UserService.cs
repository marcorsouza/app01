using App01.Model.Domain.Entities;
using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;

namespace App01.Model.Service.Services
{
    public class UserService  : BaseService<User, int> , IUserService 
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        /*public UserService() : base(new UserRepository())
        {
        }*/
    }
}

//dotnet add .\MsApp.Api\MsApp.Api.csproj reference .\MsApp.Core\MsApp.Core.csproj
