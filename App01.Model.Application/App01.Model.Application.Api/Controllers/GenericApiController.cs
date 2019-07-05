using System;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    public abstract class GenericApiController<TEntity, TType> : ApiBaseController
        where TEntity : Entity<TType>
    {
        
        public IMediator _mediator { get; }
        public IService<TEntity, TType> _service { get; }

        public GenericApiController(ILogger<Controller> logger, IMediator mediator, IService<TEntity, TType>  service) : base(logger)
        {
            this._mediator = mediator;
            //userService = new UserService();
            this._service = service;
        }

        [HttpPost]
        public async virtual Task<IActionResult> Post<TCommand>([FromBody] TCommand command) where TCommand : class, ICreateCommand<TEntity>, new()
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
    }

    public class User2Controller : GenericApiController<User, int>
    {
        public User2Controller(ILogger<Controller> logger, IMediator mediator, IUserService service) : base(logger, mediator, service)
        {
            
        }

        [HttpPost]
        public async override Task<IActionResult> Post<CreateUserCommand>([FromBody] CreateUserCommand command)
        {
            return await base.Post(command);
        }

    }
}