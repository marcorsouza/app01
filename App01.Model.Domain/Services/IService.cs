using System.Collections.Generic;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;

namespace App01.Model.Domain.Services
{
    public interface IService<T> //where T : Entity<T>
    {
        void Delete(int id);

        Task<T> Get(int id);

        Task<IEnumerable<T>> Get();
    }

    public interface IUserService : IService<User>
    {

    }
}