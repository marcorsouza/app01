using MediatR;

namespace App01.Model.Infra.CrossCutting.Features
{
    public interface IDeleteCommand<TEntity, TType> : IRequest<TEntity>
    {
        TType Id { get; }
    }
}