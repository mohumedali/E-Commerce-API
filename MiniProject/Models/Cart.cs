namespace MiniProject.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public List<CartItem> CartItems { get; set; } = new();
    }
}
