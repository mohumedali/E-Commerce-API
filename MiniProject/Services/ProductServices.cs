using AutoMapper;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.UserRepository;

namespace MiniProject.Services
{
    public class ProductServices : IProductServiceInterface
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;


        public ProductServices(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PaginationDto> GetProduct(int Page, int PageSize, int? Price)
        {
            var pro = await _repo.GetProduct(Page, PageSize, Price);
            if (Page <= 0) Page = 1;
            if (PageSize <= 0) PageSize = 10;
            var TotalCount = await _repo.TotalCount(Price);
            int TotalPages = (TotalCount + PageSize - 1) / PageSize;
            PaginationDto res = new PaginationDto()
            {
                Page = Page,
                PageSize = PageSize,
                TotalCount = TotalCount,
                TotalPages = TotalPages,
                Data = pro
            };
            return res;
        }

        public async Task AddProduct(AddProductDto product)
        {
            await _repo.AddProduct(product);
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var res = await _repo.DeleteProduct(id);
            if (!res)
                return false;
            return true;
        }
        public async Task<bool> UpdateProduct(int id, UpdateProductDto product)
        {
            var res = await _repo.UpdateProduct(id, product);
            if (!res)
                return false;
            return true;
        }
        public async Task<List<GetProductDto>> GetProductsByName(string name)
        {
            var pro = await _repo.GetProductsByName(name);
          
            if (!pro.Any() || pro == null)
            {
                return new List<GetProductDto>();
            }
            return pro;
        }

    }
}
