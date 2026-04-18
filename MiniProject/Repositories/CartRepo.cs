using Microsoft.EntityFrameworkCore;
using MiniProject.AppDbContext;
using MiniProject.DTOs;
using MiniProject.Models;

namespace MiniProject.Repositories
{
    public class CartRepo : ICartInterface
    {
        private readonly ProjectDbContext _dbContext;

        public CartRepo(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart?> GetUserById(int UserId)
        {
            return await _dbContext.Cart
                .Include(c=>c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == UserId);

        }
        public async Task AddToCart(Cart cart)
        {
            await _dbContext.Cart.AddAsync(cart);
        }

        public async Task AddToCartItems(CartItem cartItem)
        {
            await _dbContext.CartItem.AddAsync(cartItem);
        }
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
