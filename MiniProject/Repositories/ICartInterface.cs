using MiniProject.DTOs;
using MiniProject.Models;

namespace MiniProject.Repositories
{
    public interface ICartInterface
    {
       Task <Cart?> GetUserById(int UserId);
       Task AddToCart(Cart cart);
        Task AddToCartItems(CartItem cartItem);

        Task SaveChanges();

    }
}
