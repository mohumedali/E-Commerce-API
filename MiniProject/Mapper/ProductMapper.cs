using AutoMapper;
using MiniProject.DTOs;
using MiniProject.Models;

namespace MiniProject.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductModel, GetProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<GetProductDto, ProductModel>();
            CreateMap<AddProductDto, ProductModel>();

        }
    }
}
