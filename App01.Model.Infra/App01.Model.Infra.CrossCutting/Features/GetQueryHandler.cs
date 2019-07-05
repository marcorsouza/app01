using System.Threading;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features
{
    public abstract class GetQueryHandler<TEntity, TType, TQuery> : IRequestHandler<TQuery, TEntity>
        where TEntity : Entity<TType>
        where TQuery : class, IGetQuery<TEntity,TType>, new()
    {
        private readonly NotificationContext _notificationContext;
        private readonly IService<TEntity, TType> _service;

        public GetQueryHandler(NotificationContext notificationContext, IService<TEntity, TType> service)
        {
            this._notificationContext = notificationContext;
            this._service = service;
        }


        public virtual async Task<TEntity> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var query = request.Query;
            var entity = _service.Get(request.Id).Result;
            //var entity = await query.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                //throw new EntityNotFoundException<TEntity>($"Id : {request.Id}");
            }
            return entity;
        }
    }
}