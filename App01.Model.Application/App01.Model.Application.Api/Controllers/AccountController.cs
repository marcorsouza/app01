using System.Threading.Tasks;
using App01.Model.Application.Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace App01.Model.Application.Api.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        
        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _signInManager =signInManager;
            _userManager =userManager;
        }

        [HttpGet("doLogin")]
        public async Task<ActionResult> DoLogin(LoginUserViewModel loginUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(E => E.Errors));

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email,loginUser.Password,false,true);

            if(result.Succeeded)
                return Ok();
            return BadRequest("Username Or Password Incorrect");


        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(RegisterUserViewModel registerUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(E => E.Errors));

            var user = new IdentityUser{
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed=true
                
            };

            var result = await _userManager.CreateAsync(user,registerUser.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user,false);

            return Ok();
        }
    }
}