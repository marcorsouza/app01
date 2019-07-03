using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App01.Model.Domain;
using App01.Model.Domain.Entities;
using App01.Model.Infra.Data.Context.EF;
using App01.Model.Infra.Data.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace App01.Model.Infra.Data.Repositories {
    public class Repository<T> : RepositoryBase<T> where T : Entity<T> {

        protected DbSet<T> DbSet;

        public Repository (IEFUnitOfWork unitOfWork) : base (unitOfWork) {
            DbSet = unitOfWork.Context.Set<T> ();
        }

        protected override IQueryable<T> RepositoryQuery {
            get { return DbSet; }
        }

        public override async Task<T> GetById(object id)
        {
            return await DbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.IdBase.Equals(id));
        }

        public override async Task<T> Get(T entity)
        {
            return DbSet.Find(entity);
        }

        public override async Task<IQueryable<T>> GetAll () {
            return RepositoryQuery;
        }

        public override void Dispose () {

        }

        public override async Task Create(T entity, bool commit = false)
        {
            await DbSet.AddAsync(entity);

            if(commit)
                await _unitOfWork.CommitSync();
        }

        public override async Task Update(T entity, bool commit = false)
        {
            DbSet.Update(entity);
            if(commit)
                await _unitOfWork.CommitSync();
        }
    }
}