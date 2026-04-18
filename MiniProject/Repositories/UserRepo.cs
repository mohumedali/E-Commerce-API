using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniProject.AppDbContext;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.Repositories;

namespace MiniProject.UserRepository
{
    public class UserRepo : UserRepoInterface
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepo(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task CreateUser(UserModel user)
        {

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> UsernameExist(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName == username);
        }
        public async Task<bool> EmailExist(string email)
        {
            return await _dbContext.Users.AnyAsync(e => e.Email == email);
        }
        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
        }


    }
}
