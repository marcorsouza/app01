using System;
using System.Threading;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features
{
    public abstract class DeleteCommandHandler<TEntity, TType, TCommand> : IRequestHandler<TCommand, bool>
        where TEntity : Entity<TType>
        where TCommand : class, IDeleteCommand<TEntity, TType>, new()
    {
        private readonly NotificationContext _notificationContext;
        private readonly IService<TEntity, TType> _service;

        public DeleteCommandHandler(NotificationContext notificationContext, IService<TEntity, TType> service)
        {
            this._notificationContext = notificationContext;
            this._service = service;
        }

        public async Task<bool> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _service.Get(request.Id).Result;

            if (entity == null)
            {
                //throw new EntityNotFoundException<TEntity>($"Id : {request.Id}");
            }

            try{
                _service.Delete(entity.Id);
                return true;
            }catch(Exception ex){
                throw ex;
            }
        }

        /*
        public async Task<TType> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _service.Get(request.Id).Result;

            if (entity == null)
            {
                //throw new EntityNotFoundException<TEntity>($"Id : {request.Id}");
            }

            _service.Delete(entity.Id);

            return request.Id;
        }*/
    }
}