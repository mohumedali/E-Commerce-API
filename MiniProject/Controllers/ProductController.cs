using Microsoft.AspNetCore.Mvc;
using MiniProject.DTOs;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceInterface _ProService;

        public ProductController(IProductServiceInterface productService)
        {
            _ProService = productService;
        }
        //[Authorize]
        [HttpPost("Get-Product")]
        public async Task<IActionResult> GetProduct(int Page, int PageSize, int? Price)
        {
            return Ok(await _ProService.GetProduct(Page, PageSize, Price));
        }
        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto product)
        {
            try
            {
                await _ProService.AddProduct(product);
                return Ok(new { message = "Product Added ✅ " });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }

        }
        [HttpDelete("Delete-Product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var pro = await _ProService.DeleteProduct(id);
            if (!pro)
                return NotFound(new { message = "Product Not Found " });
            return Ok(new { message = "Product Deleted ✅ " });
        }
        [HttpPut("Update-Product")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] UpdateProductDto product)
        {
            var pro = await _ProService.UpdateProduct(id, product);
            if (!pro)
                return NotFound(new { message = "Product Not Found " });
            return Ok(new { message = "Product Updated ✅ " });
        }

        [HttpGet("Search-By-Name")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var pro = await _ProService.GetProductsByName(name);
            if (!pro.Any())
            {
                return NotFound("Product not found");
            }
            return Ok(pro);
        }
    }
}
