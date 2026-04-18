using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.DTOs;
using MiniProject.ServiceResponse;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpPost("Add-To-Cart")]
        public async Task<IActionResult> AddToCart(int UserId, [FromForm] AddToCartDto dto)
        {
            try
            {
                var response = await _cartServices.AddToCart(UserId, dto);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message;
                return BadRequest(inner);
            }
        }
    }
}
