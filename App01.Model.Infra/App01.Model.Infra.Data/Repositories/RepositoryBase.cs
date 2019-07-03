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
    public abstract class RepositoryBase<T> : IRepository<T> {
        protected readonly IUnitOfWork _unitOfWork;

        public RepositoryBase (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        protected abstract IQueryable<T> RepositoryQuery { get; }

        public abstract Task<T> GetById(object id);
        public abstract Task<T> Get(T entity);
        public abstract Task<IQueryable<T>> GetAll ();
        public abstract Task Create (T entity, bool commit = false);
        public abstract Task Update(T entity, bool commit = false);

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator () {
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