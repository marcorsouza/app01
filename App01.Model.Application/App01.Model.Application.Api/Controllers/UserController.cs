using System.Collections.Generic;
using System.Threading.Tasks;
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

        public UserController(ILogger<UserController> logger) : base(logger)
        {
            userService = new UserService();
        }

        public UserService userService { get; }

        /// <summary>
        /// Action Get
        /// </summary>
        /// <param name="id">Codigo do Usuario</param>
        /// <returns>Retorna Usuario</returns>
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            var users = userService.Get().Result;

            //var user = await userService.Get(1);

            return new ObjectResult(users);

            var objectResult = new ObjectResult(new List<object>(){
                new {Id = 1, Nome="Marco Souza", Email="marco.souza@tecon.com.br"}, 
                new {Id = 2, Nome="Gabriel", Email="gasr@tecon.com.br"}
            });
            return objectResult;
        }
    }
}