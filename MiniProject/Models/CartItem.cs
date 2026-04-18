namespace MiniProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; }

    }
}
