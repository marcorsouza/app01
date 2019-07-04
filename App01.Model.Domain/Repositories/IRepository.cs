using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App01.Model.Domain.Repositories {
    public interface IRepository : IDisposable {

    }

    public interface IRepository<TEntity, TType> : IQueryable<TEntity>, IRepository {

        Task<TEntity> GetById(TType id);
        Task<TEntity> Get(TEntity entity);
        Task<IQueryable<TEntity>> GetAll ();
        Task Create(TEntity entity, bool commit=false);
        Task Update(TEntity entity, bool commit = false);
        void Delete(TType id, bool commit = false);
    }
}