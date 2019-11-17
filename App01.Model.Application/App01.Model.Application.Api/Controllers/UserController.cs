using System.Net;
using System.Threading.Tasks;
using App01.Model.Application.Api.Controllers.Base;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User, int>
    {
        public UserController(ILogger<Controller> logger, IMediator mediator, IUserService service) : base(logger, mediator, service)
        {
            
        }

        [Authorize]
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if(id.HasValue){
                return await _getId( new UserGetQuery() { Id = id.Value});
            }else{
                return new NoContentResult();
            }

            return new NotFoundResult();
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