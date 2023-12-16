using Domain.Models;

namespace SolarEnergy.Dtos
{
    public class ProductCreateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
      //  public IFormFile? FilePath { get; set; }
        public decimal Price { get; set; }
        public CategoryDto? Category { get; set; }
        public List<IFormFile> FileImages { get; set; }
    }
}
