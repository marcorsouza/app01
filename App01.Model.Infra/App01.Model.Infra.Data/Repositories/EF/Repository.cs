using App01.Model.Domain.Entities;
using App01.Model.Infra.Data.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App01.Model.Infra.Data.Repositories
{
    public class Repository<TEntity, TType> : RepositoryBase<TEntity, TType> 
        where TEntity : Entity<TType>
    {

        protected DbSet<TEntity> DbSet;

        public Repository (IEFUnitOfWork unitOfWork) : base (unitOfWork) {
            DbSet = unitOfWork.Context.Set<TEntity> ();
        }

        protected override IQueryable<TEntity> RepositoryQuery {
            get { return DbSet; }
        }

        public override async Task<TEntity> GetById(TType id)
        {
            return await DbSet.FindAsync(id);
        }

        public override async Task<TEntity> Get(TEntity entity)
        {
            return await DbSet.FindAsync(entity);
        }

        public override async Task<IQueryable<TEntity>> GetAll () {
            return RepositoryQuery;
        }

        public override void Dispose () {
           // ((IEFUnitOfWork)_unitOfWork).Context.Dispose();
           // GC.SuppressFinalize(this);
        }

        public override void Create(TEntity entity, bool commit = false)
        {
            DbSet.Add(entity);
            if (commit)
                _unitOfWork.Commit();
        }

        public override void Update(TEntity entity, bool commit = false)
        {
            DbSet.Update(entity);
            if(commit)
                _unitOfWork.Commit();
        }

        public override void Delete(TType id, bool commit = false)
        {
            DbSet.Remove(DbSet.Find(id));
            if (commit)
                _unitOfWork.CommitSync();
        }
    }
}