using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App01.Model.Domain;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Repositories;

namespace App01.Model.Infra.Data.Repositories {
    public abstract class RepositoryBase<TEntity, TType> : IRepository<TEntity, TType> {

        public IUnitOfWork UnitOfWork { get; private set; }

        public RepositoryBase (IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }

        protected abstract IQueryable<TEntity> RepositoryQuery { get; }

        public abstract Task<TEntity> GetById(TType id);
        public abstract Task<TEntity> Get(TEntity entity);
        public abstract Task<IQueryable<TEntity>> GetAll ();
        public abstract void Create (TEntity entity, bool commit = false);
        public abstract void Update(TEntity entity, bool commit = false);
        public abstract void Delete(TType id, bool commit = false);

        #region IEnumerable<TEntity> Members

        public IEnumerator<TEntity> GetEnumerator () {
            return RepositoryQuery.GetEnumerator ();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator () {
            return RepositoryQuery.GetEnumerator ();
        }

        #endregion

        #region IQueryable Members

        public Type ElementType {
            get {
                return RepositoryQuery.AsQueryable ().ElementType;
            }

        }

        public Expression Expression {
            get {
                return RepositoryQuery.AsQueryable ().Expression;
            }
        }

        public IQueryProvider Provider {
            get {
                return RepositoryQuery.AsQueryable ().Provider;
            }
        }

        #endregion
        public abstract void Dispose ();
    }
}