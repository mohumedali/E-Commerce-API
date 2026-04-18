using MiniProject.Models;

namespace MiniProject.DTOs
{
    public class GetProductDto
    {
        public string ProductName { get; set; }


        public int Quantity { get; set; }


        public decimal Price { get; set; }
        public string Category { get; set; } 
    }
}
