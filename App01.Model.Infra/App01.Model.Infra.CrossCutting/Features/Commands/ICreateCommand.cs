using App01.Model.Domain;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features.Commands
{
    public interface ICreateCommand<TEntity> : IRequest<TEntity>
    {
    }
}