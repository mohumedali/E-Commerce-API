using AutoMapper;
using MiniProject.DTOs;
using MiniProject.Models;
using System.Runtime;

namespace MiniProject.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserModel, GetUsersDto>();
            CreateMap<UserRegisterDto, UserModel>();


        }
    }
}
