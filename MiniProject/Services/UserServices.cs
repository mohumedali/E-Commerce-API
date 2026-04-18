
using AutoMapper;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniProject.Services
{
    public class UserServices : IUserService
    {
        private readonly UserRepoInterface _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;


        public UserServices(UserRepoInterface repo, IMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
        }
        public String HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verfiy(string password, string HashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashPassword);

        }

        public async Task CreateUser(UserRegisterDto dto)
        {

            if (await _repo.UsernameExist(dto.UserName))
            {
                throw new Exception("this Name is already exist");
            }
            else if (await _repo.EmailExist(dto.Email))
            {
                throw new Exception("this Email is already exist");
            }
            var user = _mapper.Map<UserModel>(dto);
            user.Password = HashPassword(dto.Password);
            await _repo.CreateUser(user);

        }
        public async Task<string> Login(UserLoginDto dto)
        {
            var ExistUser = await _repo.GetUserByEmail(dto.Email);
            if (ExistUser == null)
            {
                throw new Exception("This User doesn't exist");
            }

            var PassCheck = Verfiy(dto.Password, ExistUser.Password);
            if (!PassCheck)
                throw new Exception("Invalid email or password");

            return GenerateToken(ExistUser);


        }

        public string GenerateToken(UserModel user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: Claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
