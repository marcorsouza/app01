using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers.Base
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