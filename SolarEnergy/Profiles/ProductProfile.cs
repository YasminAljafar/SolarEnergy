using AutoMapper;
using Domain.Models;
using SolarEnergy.Dtos;
using SolarEnergy.Profiles;
using SolarEnergy.Services;

namespace SolarEnergy.Mapper
{
    public class ProductProfile:Profile
    {
        private IWebHostEnvironment  _webHostEnvironment;

        public ProductProfile()
        {

        }
        public ProductProfile(IWebHostEnvironment webHostEnvironment) 
        {
            _webHostEnvironment = webHostEnvironment;
            CreateMap<ProductCreateDto, Product>().ForMember(s => s.FilePath, d => d.Ignore());
            CreateMap<CategoryDto, Category>().ReverseMap();
            //.ForMember(s=>s.FilePath,d=>d.MapFrom(src => new UploadFile(_webHostEnvironment)
            //.SaveFile(src.FilePath)));
            //.ForMember(s=>s.ImagePath,d=>d.Ignore());
            //   .ForMember(dest => dest.FileImages, opt => opt.MapFrom(src => src.FileImages));
            CreateMap<Image, ImagesDto>().ReverseMap();
        }
    }
}
