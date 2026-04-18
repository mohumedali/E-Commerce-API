using MiniProject.Models;

namespace MiniProject.Repositories
{
    public interface UserRepoInterface
    {
        Task CreateUser(UserModel user);
        Task<bool> UsernameExist(string username);
        Task<bool> EmailExist(string email);
        Task<UserModel> GetUserByEmail(string email);

    }
}
