using MiniProject.DTOs;
using MiniProject.Models;

namespace MiniProject.UserRepository
{
    public interface IProductRepo
    {
        Task<List<GetProductDto>> GetProduct(int Page, int PageSize, int? Price);
        Task<int> TotalCount(int? Price);
        Task AddProduct (AddProductDto product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, UpdateProductDto product);
        Task<ProductModel?> GetProductById(int id);
        Task<List<GetProductDto>> GetProductsByName(string name);

    }
}
