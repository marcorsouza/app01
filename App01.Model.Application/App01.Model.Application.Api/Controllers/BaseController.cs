using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    /// <summary>
    /// Controller Base da Aplicação
    /// </summary>
    public abstract class BaseController : Controller
    {
        protected readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}