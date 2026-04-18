namespace MiniProject.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal TotalPrice { get; set; }

        public List<ProductOrderModel> ProductOrders { get; set; } = new();

        public int UserId { get; set; }

        public UserModel User { get; set; }
    }
}
