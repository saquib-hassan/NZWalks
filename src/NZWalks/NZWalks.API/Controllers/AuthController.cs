using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
