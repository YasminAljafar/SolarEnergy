using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarEnergy.Dtos
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
     //   public string? FilePath { get; set; }
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public List<ImagesDto>? FileImages { get; set; }

    }
}
