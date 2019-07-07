using System;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features
{
    public interface IDeleteCommand<TEntity, TType> : IRequest<bool>
    {
        TType Id { get; }
    }
}