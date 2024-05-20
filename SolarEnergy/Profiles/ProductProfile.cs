using AutoMapper;
using Domain.Enums;
using Domain.Models;
using SolarEnergy.Dtos;
using SolarEnergy.Profiles;
using SolarEnergy.Services;

namespace SolarEnergy.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductCreateDto, Product>().ReverseMap();
                //.ReverseMap().ForMember(s=>s.FileImages,s=>s.Ignore());
            CreateMap<ProductGetDto, Product>().ReverseMap();
            CreateMap<Image, ImagesDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
