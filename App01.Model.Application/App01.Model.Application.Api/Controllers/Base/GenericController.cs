using System;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers.Base
{
    public abstract class GenericController<TEntity, TType> : ApiBaseController
        where TEntity : Entity<TType>
        where TType : struct
    {
        
        public IMediator _mediator { get; }
        public IService<TEntity, TType> _service { get; }

        public GenericController(ILogger<Controller> logger, IMediator mediator, IService<TEntity, TType>  service) : base(logger)
        {
            this._mediator = mediator;
            this._service = service;
        }

        protected async Task<IActionResult> _post<TCommand>(TCommand command)
            where TCommand : class, ICreateCommand<TEntity>, new()
        {
            try
            {
                var user = await _mediator.Send(command);
                return new ObjectResult(user);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
           
        protected async Task<IActionResult> _put<TCommand>(TCommand command)
            where TCommand : class, IUpdateCommand<TEntity, TType>, new()
        {
            try
            {
                var user = await _mediator.Send(command);
                return new ObjectResult(user);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        protected async Task<IActionResult> _delete<TCommand>(TCommand command)
            where TCommand : class, IDeleteCommand<TEntity, TType>, new()
        {
            try
            {
                MediatR.Unit result = await _mediator.Send(command);
                return new ObjectResult(result);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        public async Task<IActionResult> _getId<TCommand>(TCommand command)
            where TCommand : class, IGetQuery<TEntity, TType>, new()
        {
            var entity = await _mediator.Send(command);

            if(entity !=null){
                return new ObjectResult(entity);
            }
            return new NoContentResult();
        }
    }
}