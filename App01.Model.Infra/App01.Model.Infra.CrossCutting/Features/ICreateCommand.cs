using App01.Model.Domain;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features
{
    public interface ICreateCommand<TEntity> : IRequest<TEntity>
    {
    }
}