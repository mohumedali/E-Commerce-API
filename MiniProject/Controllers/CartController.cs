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
        [HttpPost("Get-Cart")]
        public async Task<IActionResult> GetCart([FromForm] int UserId)
        {
            var cart = await _cartServices.GetCart(UserId);
            return Ok(cart);
        }
        [HttpDelete("Delete-Cart-Item")]
        public async Task<IActionResult> RemoveCartItem(int UserId, int ProductId)
        {
            var res = await _cartServices.RemoveCartItem(UserId, ProductId);
            return Ok(res);
        }
        [HttpPut("updated-cart-item")]
        public async Task<IActionResult>UpdateCartItem(int UserId,[FromForm] UpdateCartItemDto dto)
        {
            var res = await _cartServices.UpdateCartItem(UserId, dto);
            return Ok(res);
        }
        [HttpDelete("DeleteAll-Cart-Item")]
        public async Task<IActionResult> DeleteAllCartItem(int UserId)
        {
            var res = await _cartServices.DeleteAllCartItems(UserId);
            return Ok(res);
        }
    }
}
