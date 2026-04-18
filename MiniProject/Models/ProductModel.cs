namespace MiniProject.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }


        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }
        public List<ProductOrderModel> ProductOrders { get; set; } = new();
    }
}
