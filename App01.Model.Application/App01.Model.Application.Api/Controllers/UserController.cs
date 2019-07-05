using System.Threading.Tasks;
using App01.Model.Application.Api.Controllers.Base;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : GenericController<User, int>
    {
        public UserController(ILogger<Controller> logger, IMediator mediator, IUserService service) : base(logger, mediator, service)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            return await _post(command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            return await _put(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteUserCommand();
            request.Id = id;
            return await _delete(request);
        }

    }
}