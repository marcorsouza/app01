using System.Linq;
using System;
using System.Collections.Generic;
using FluentValidation;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;
using App01.Model.Infra.Data.Repositories;
using System.Threading.Tasks;

namespace App01.Model.Service.Services
{

    public class BaseService<T> : IService<T> where T : Entity
    {
        private readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            var lst = await repository.GetAll();
            return lst;
        }

        /* public T Post<V>(T obj) where V : AbstractValidator<T>
          {
              Validate(obj, Activator.CreateInstance<V>());

              //repository.Insert(obj);
              return obj;
          }

          public T Put<V>(T obj) where V : AbstractValidator<T>
          {
              Validate(obj, Activator.CreateInstance<V>());

              //repository.Update(obj);
              return obj;
          }

          public void Delete(int id)
          {
              repository.Delete(id);
          }

          public T Get(int id)
          {
              return repository.Get(id);
          }

          public IEnumerable<T> Get()
          {
              return repository.List();
          }

          private void Validate(T obj, AbstractValidator<T> validator)
          {
              if (obj == null)
                  throw new Exception("Registros não detectados!");

              validator.ValidateAndThrow(obj);
          } */
    }
}

//dotnet add .\MsApp.Api\MsApp.Api.csproj reference .\MsApp.Core\MsApp.Core.csproj
