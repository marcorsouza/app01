using System.Net;
using System.Threading.Tasks;
using App01.Model.Application.Api.Controllers.Base;
using App01.Model.Application.Api.Filters;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User, int>
    {
        public UserController(ILogger<Controller> logger, IMediator mediator, IUserService service) : base(logger, mediator, service)
        {
            
        }

        
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

        [ClaimsAuthorize("User","Insert")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            return await _post(command);
        }

        [ClaimsAuthorize("User","Edit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            return await _put(command);
        }

        [ClaimsAuthorize("User","Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteUserCommand();
            request.Id = id;
            return await _delete(request);
        }

    }
}