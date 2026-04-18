using MiniProject.DTOs;

namespace MiniProject.Services
{
    public interface IUserService
    {
        Task CreateUser(UserRegisterDto dto);
        //Task<List<GetUsersDto>> GetUsers();
        Task<string> Login(UserLoginDto dto);

    }
}
