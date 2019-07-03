using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App01.Model.Application.Api.Controllers
{
    /// <summary>
    /// Controller Home
    /// </summary>
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(){
            return View();
        }
    }
}