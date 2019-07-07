using MediatR;
using System;
using System.Linq;

namespace App01.Model.Infra.CrossCutting.Features
{
    public interface IGetQuery<TEntity, TType> : IRequest<TEntity>
    {
        IQueryable<TEntity> Query { get; set; }
        TType Id { get; }
    }
}