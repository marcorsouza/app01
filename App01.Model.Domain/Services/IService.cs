using System.Collections.Generic;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;

namespace App01.Model.Domain.Services
{
    public interface IService
    {

    }

    public interface IService<T, R> : IService
    {
        void Delete(R id);

        Task<T> Get(R id);

        Task<IEnumerable<T>> Get();
    }

    public interface IUserService : IService<User, int>
    {

    }
}