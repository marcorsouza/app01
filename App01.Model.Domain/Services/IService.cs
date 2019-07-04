using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

namespace App01.Model.Domain.Services
{
    public interface IService {

    }

    public interface IService<TEntity, TType> : IService {

        TEntity Post<V> (TEntity obj) where V : AbstractValidator<TEntity>;

        TEntity Put<V> (TEntity obj) where V : AbstractValidator<TEntity>;
        
        void Delete (TType id);

        Task<TEntity> Get (TType id);

        Task<IEnumerable<TEntity>> Get ();
    }
}