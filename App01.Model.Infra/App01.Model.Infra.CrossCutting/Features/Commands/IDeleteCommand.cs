using System;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features.Commands
{
    public interface IDeleteCommand<TEntity, TType> : IRequest
    {
        TType Id { get; }
    }
}