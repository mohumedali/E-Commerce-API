using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.ServiceResponse;

namespace MiniProject.Services
{
    public interface ICartServices
    {
        Task<ServiceResponse<AddToCartDto>> AddToCart(int UserId,AddToCartDto addProduct);
        Task<ServiceResponse<GetCartDto>> GetCart(int UserId);

        Task<ServiceResponse<string>> RemoveCartItem(int UserId,int ProductId);
        Task<ServiceResponse<string>> UpdateCartItem(int UserId, UpdateCartItemDto dto);
        Task<ServiceResponse<string>> DeleteAllCartItems(int UserId);


    }
}
