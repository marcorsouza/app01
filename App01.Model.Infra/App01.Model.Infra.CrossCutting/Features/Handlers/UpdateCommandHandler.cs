using System.Threading;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.Commands;
using App01.Model.Infra.CrossCutting.Notifications;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features.handlers
{

    public abstract class UpdateCommandHandler<TEntity, TType, TValidator, TCommand> : IRequestHandler<TCommand, TEntity>
        where TCommand : class, IUpdateCommand<TEntity, TType>, new()
        where TValidator : AbstractValidator<TEntity>
        where TEntity : Entity<TType>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IService<TEntity, TType> _service;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(NotificationContext notificationContext, IService<TEntity, TType> service, IMapper mapper)
        {
            this._notificationContext = notificationContext;
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _service.Get(request.Id).Result;
            entity = _mapper.Map<TCommand, TEntity>(request, entity);

            _service.Put<TValidator>(entity);

            if (entity.Invalid)
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            return entity;
        }
    }
}