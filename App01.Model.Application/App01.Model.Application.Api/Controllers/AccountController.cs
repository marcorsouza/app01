using System.Text;
using System.Threading.Tasks;
using App01.Model.Application.Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using App01.Model.Infra.CrossCutting.Security.JWT;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;

namespace App01.Model.Application.Api.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly TokenConfigurations _tokenConfigurations;

        
        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,
        IOptions<TokenConfigurations> tokenConfigurations)
        {
            _signInManager =signInManager;
            _userManager =userManager;
            _tokenConfigurations = tokenConfigurations.Value;
        }

        [HttpGet("doLogin")]
        public async Task<ActionResult> DoLogin(LoginUserViewModel loginUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(E => E.Errors));

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email,loginUser.Password,false,true);

            if(result.Succeeded)
                return Ok(await CreateJwt(loginUser.Email));
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

            return Ok(await CreateJwt(registerUser.Email));
        }


        private async Task<string> CreateJwt(string email){
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenConfigurations.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Issuer = _tokenConfigurations.Issuer,
                Audience=_tokenConfigurations.Audience,
                Expires=DateTime.UtcNow.AddHours(_tokenConfigurations.Hours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            if(tokenDescriptor != null)
            return _tokenConfigurations.Secret;
            return "teste";
        }
    }
}