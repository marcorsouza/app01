using MediatR;
using System;

namespace App01.Model.Infra.CrossCutting.Features
{
    public interface IUpdateCommand<TEntity, TType> : IRequest<TEntity>
    {
        TType Id { get; }
    }
}