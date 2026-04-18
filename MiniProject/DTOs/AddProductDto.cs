namespace MiniProject.DTOs
{
    public class AddProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
