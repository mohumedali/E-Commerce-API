using Microsoft.EntityFrameworkCore;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.Repositories;
using MiniProject.ServiceResponse;
using MiniProject.UserRepository;
using System.Diagnostics.Eventing.Reader;

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
                    Message = "Product not Found"
                };
            }
            var cart = await _repo.GetUserById(UserId);
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = UserId,
                    CartItems = new List<CartItem>()
                };
                await _repo.AddToCart(cart);
                await _repo.SaveChanges();
            }
            else
            {
                var cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == dto.ProductId);
                if (cartItem == null)
                {
                    cartItem = new CartItem()
                    {
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity,
                        CartId = cart.Id
                    };
                    await _repo.AddToCartItems(cartItem);
                }
                else
                {
                    product.Quantity -= dto.Quantity;
                    cartItem.Quantity += dto.Quantity;
                }
            }
                await _repo.SaveChanges();

                return new ServiceResponse<AddToCartDto>()
                {
                    Success = true,
                    Message = "Added To Cart",
                    Data = dto
                };
        }
        public async Task<ServiceResponse<GetCartDto>> GetCart(int userId)
        {
            var Cart = await _repo.GetCartByUserId(userId);
            if (Cart == null)
            {
                return new ServiceResponse<GetCartDto>()
                {
                    Success = false,
                    Message = "The Cart is Empty"
                };
            }
            else
            {
               
                var items = Cart.CartItems.Select(c => new CartItemDto
                {
                    ProductName = c.Product.ProductName,
                    Price = c.Product.Price,
                    Quantity = c.Quantity,
                    
                }).ToList();

                var Total = Cart.CartItems.Sum(c => c.Quantity * c.Product.Price);
                var res = new GetCartDto
                {
                    cartItems = items,
                    TotalPrice = Total

                };


                return new ServiceResponse<GetCartDto>()
                {
                    Success = true,
                    Data = res
                };
            }

        }
        public async Task<ServiceResponse<string>> RemoveCartItem(int UserId,int ProductId)
        {
            var cart = await _repo.GetUserById(UserId);
            if(cart == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Cart Not Found"
                };
            }
            var items = cart.CartItems.FirstOrDefault(o => o.ProductId == ProductId);
            if(items == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Product doesn't exist in cart"
                };
            }
            cart.CartItems.Remove(items);
            await _repo.SaveChanges();

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Product Deleted"
            };
        }
        public async Task<ServiceResponse<string>> UpdateCartItem(int UserId,UpdateCartItemDto dto)
        {
            var cart = await _repo.GetUserById(UserId);
            if (cart == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Cart doesn't Exist"
                };

            }
            else
            {
                var items = cart.CartItems.FirstOrDefault(o => o.ProductId == dto.ProductId);
                if(items == null)
                {
                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = "Product doesn't exist in your Cart"
                    };
                }
                if(dto.Quantity <= 0)
                {
                    cart.CartItems.Remove(items);
                }
                else
                {
                    items.Quantity = dto.Quantity;
                    
                }
                await _repo.SaveChanges();
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Product Quantity Updated"

                };
            }
        }
        public async Task<ServiceResponse<string>> DeleteAllCartItems(int UserId)
        {
            var cart = await _repo.GetUserById(UserId);
            if (cart == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Cart already Doesn't exist"
                };
            }
            if (!cart.CartItems.Any())
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Cart is already empty"
                };
            }
            cart.CartItems.Clear();
            await _repo.SaveChanges();
            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Cart Cleared"
            };
        }
    }


}







