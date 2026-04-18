namespace MiniProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = "User";

        public List<OrderModel> Orders { get; set; }
        public Cart Cart { get; set; }
    }
}
