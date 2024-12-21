using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddRegisterRequestDto addRegisterRequestDto)
        {
            var identityUser = new IdentityUser()
            {
                UserName = addRegisterRequestDto.UserName,
                Email = addRegisterRequestDto.UserName
            };

            var identityResult = await userManager.CreateAsync(identityUser, addRegisterRequestDto.Password);
            if(identityResult.Succeeded)
            {
                if(addRegisterRequestDto.Roles != null && addRegisterRequestDto.Roles.Any() )
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, addRegisterRequestDto.Roles);
               

                if(identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login");
                }
                }
            }
            return BadRequest("Something went wrong");
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var identityUser = await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if(identityUser != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);
                
                if(checkPasswordResult)
                {
                    // create role

                    var roles = await userManager.GetRolesAsync(identityUser);
                    if(roles != null)
                    {
                        // create jwt token

                        var token = tokenRepository.CreateJWTToken(identityUser, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = token
                        };

                        return Ok(response);
                    }

                }
                
            }

            return BadRequest("Username or Password was incorrect");
        }
    }
}
