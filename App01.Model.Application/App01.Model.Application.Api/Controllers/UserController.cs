using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using App01.Model.Service.Services;
using App01.Model.Service.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    /// <summary>
    /// Controller Api User
    /// </summary>
    public class UserController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator, IUserService userService) : base(logger)
        {
            this._mediator = mediator;
            //userService = new UserService();
            this.userService = userService;
        }

        public IUserService userService { get; }

        /// <summary>
        /// Action Get
        /// </summary>
        /// <param name="id">Codigo do Usuario</param>
        /// <returns>Retorna Usuario</returns>
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            ObjectResult result;

            if (id.HasValue)
            {
                var user = userService.Get(id.Value).Result;
                result = new ObjectResult(user);
            }
            else
            {
                var users = userService.Get().Result;
                result = new ObjectResult(users);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUser command)
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

        public IActionResult Delete(int id)
        {
            try
            {
                userService.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}