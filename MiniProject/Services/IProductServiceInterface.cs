using MiniProject.DTOs;
using MiniProject.Models;

namespace MiniProject.Services
{
    public interface IProductServiceInterface
    {
        Task<PaginationDto> GetProduct(int Page, int PageSize, int? Price);
        Task AddProduct(AddProductDto product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id,UpdateProductDto product);
        Task<List<GetProductDto>> GetProductsByName(string name);



    }
}
