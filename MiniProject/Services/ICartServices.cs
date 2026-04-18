using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.ServiceResponse;

namespace MiniProject.Services
{
    public interface ICartServices
    {
        Task<ServiceResponse<AddToCartDto>> AddToCart(int UserId,AddToCartDto addProduct);
    }
}
