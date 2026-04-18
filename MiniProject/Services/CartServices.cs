using Microsoft.EntityFrameworkCore;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.Repositories;
using MiniProject.ServiceResponse;
using MiniProject.UserRepository;

namespace MiniProject.Services
{
    public class CartServices :ICartServices
    {
        private readonly ICartInterface _repo;
        private readonly IProductRepo _proRepo;
        public CartServices(ICartInterface repo, IProductRepo proRepo)
        {
            _repo = repo;
            _proRepo = proRepo;
        }
        
        public async Task<ServiceResponse<AddToCartDto>> AddToCart(int UserId,AddToCartDto dto)
        {
            var product = await _proRepo.GetProductById(dto.ProductId);
            if (product == null)
            {
                return new ServiceResponse<AddToCartDto>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }
            var Cart = await _repo.GetUserById(UserId);
            if (Cart == null)
            {
                Cart = new Cart() { 
                    UserId = UserId,
                    CartItems = new List<CartItem>()
                };
                await _repo.AddToCart(Cart);
                await _repo.SaveChanges();

            }

            var items = Cart.CartItems.FirstOrDefault(x => x.ProductId == dto.ProductId);
            if (items != null)
            {
                items.Quantity += dto.Quantity;

            }
            else
            {
                items = new CartItem()
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    CartId = Cart.Id

                }; 
                await _repo.AddToCartItems(items);

            }
               
            await _repo.SaveChanges();
            return new ServiceResponse<AddToCartDto>()
            {
                Success = true,
                Message = "Product added to cart successfully",
                Data = dto
            };

        }
    }
}
