using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    /// <summary>
    /// Controler Api Base
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : BaseController
    {
        public ApiBaseController(ILogger logger) : base(logger)
        {
        }
    }
}