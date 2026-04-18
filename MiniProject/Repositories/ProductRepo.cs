using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniProject.AppDbContext;
using MiniProject.DTOs;
using MiniProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MiniProject.UserRepository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProjectDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductRepo(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<GetProductDto>> GetProduct(int Page, int PageSize, int? Price)
        {
            var query = _dbcontext.Products.AsQueryable();
            if (Price.HasValue)
                query = query.Where(p => p.Price <= Price);
            var data = await query.Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new GetProductDto
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category = p.Category.Name
                }).ToListAsync();
            return data;

        }
        public async Task<int> TotalCount(int? Price)
        {
            var query = _dbcontext.Products.AsQueryable();

            if (Price.HasValue)
                query = query.Where(p => p.Price <= Price);

            return await query.CountAsync();

        }

        public async Task AddProduct(AddProductDto product)
        {
            var pro = _mapper.Map<ProductModel>(product);
            await _dbcontext.Products.AddAsync(pro);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var pro = await _dbcontext.Products.FindAsync(id);
            if (pro != null)
            {
                _dbcontext.Products.Remove(pro);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateProduct(int id, UpdateProductDto product)
        {
            var pro = await _dbcontext.Products.FindAsync(id);
            if (pro != null)
            {
                pro.ProductName = product.ProductName;
                pro.Price = product.Price;
                pro.Quantity = product.Quantity;
                pro.CategoryId = product.CategoryId;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductModel?> GetProductById(int id)
        {
            return await _dbcontext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<GetProductDto>> GetProductsByName(string name)
        {
            var pro = await _dbcontext.Products.Include(p => p.Category).Where(n=>EF.Functions.Like(n.ProductName,$"%{name}%")).ToListAsync();
            var data = pro.Select(p => new GetProductDto
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Quantity = p.Quantity,
                Category = p.Category?.Name ?? "No Category"
            }).ToList();
            return data;

        }
    }
}
