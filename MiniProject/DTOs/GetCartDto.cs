namespace MiniProject.DTOs
{
    public class GetCartDto
    {
        public List<CartItemDto>? cartItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
