﻿using App01.Model.Domain.Entities;
using App01.Model.Infra.Data.Repositories.EF;
using Microsoft.EntityFrameworkCore;
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
            return await DbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public override async Task<TEntity> Get(TEntity entity)
        {
            return await DbSet.FindAsync(entity);
        }

        public override async Task<IQueryable<TEntity>> GetAll () {
            return RepositoryQuery;
        }

        public override void Dispose () {

        }

        public override async Task Create(TEntity entity, bool commit = false)
        {
            await DbSet.AddAsync(entity);

            if(commit)
                await _unitOfWork.CommitSync();
        }

        public override async Task Update(TEntity entity, bool commit = false)
        {
            DbSet.Update(entity);
            if(commit)
                await _unitOfWork.CommitSync();
        }
    }
}