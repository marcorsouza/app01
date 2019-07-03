using System.Collections.Generic;
using System.Threading.Tasks;
using App01.Model.Application.Api.Models;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    /// <summary>
    /// Controller Api User
    /// </summary>
    public class UserController : ApiBaseController
    {

        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
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
            else {
                var users = userService.Get().Result;
                result = new ObjectResult(users);
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]NewUserViewModel viewModel)
        {
            var user = new Domain.Entities.User(){
                Name = viewModel.Name,
                Email = viewModel.Email,
                Active=true,
                Cpf=viewModel.Cpf,
                BirthDate = viewModel.BirthDate
            };

            user.Authentication.Username = viewModel.AuthenticationUserName;
            user.Authentication.Password = viewModel.AuthenticationPassword;
            return  new ObjectResult(user);
        }
    }
}