using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;
using App01.Model.Service.Validators;
using FluentValidation;

namespace App01.Model.Service.Services {

    public class BaseService<TEntity, TType> : IService<TEntity, TType>
        where TEntity : Entity<TType> {
        private readonly IRepository<TEntity, TType> repository;

        public BaseService (IRepository<TEntity, TType> repository) {
            this.repository = repository;
        }

        public TEntity Post<V> (TEntity entity) where V : AbstractValidator<TEntity> {

            entity.Validate<TEntity>(entity, Activator.CreateInstance<V>());

            //Validate (obj, Activator.CreateInstance<V> ());
            if (entity.Valid)
                repository.Create(entity, true);
            return entity;
        }

        public TEntity Put<V> (TEntity entity) where V : AbstractValidator<TEntity> {
            entity.Validate<TEntity>(entity, Activator.CreateInstance<V>());

            if (entity.Valid)
                repository.Update(entity,true);
            return entity;
        }

        public void Delete(TType id)
        {
            repository.Delete(id,true);
        }
        
        public async Task<TEntity> Get (TType id) {
            return await repository.GetById (id);
        }

        public async Task<IEnumerable<TEntity>> Get () {
            var lst = await repository.GetAll ();
            return lst;
        }
    }
}

//dotnet add .\MsApp.Api\MsApp.Api.csproj reference .\MsApp.Core\MsApp.Core.csproj