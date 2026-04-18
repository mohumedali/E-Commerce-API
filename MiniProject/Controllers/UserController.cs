using Microsoft.AspNetCore.Mvc;
using MiniProject.DTOs;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;
        public UserController(IUserService services)
        {
            _services = services;
        }
        //[Authorize(Roles = "user")]
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromForm] UserRegisterDto dto)
        {
            try
            {
                await _services.CreateUser(dto);
                return Ok(new { message = "User Created ✅ " });
            }
            catch (Exception ex)
            {

                return BadRequest(new { Error = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserLoginDto dto)
        {
            try
            {
                var ValidUser = await _services.Login(dto);
                return Ok(new
                {
                    message = "Login Successfully",
                    ValidUser
                });


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
