using Domain.Models;

namespace SolarEnergy.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? FilePath { get; set; }
        public decimal Price { get; set; }
        //multiple images
        public Category Category { get; set; }
        public List<Image>? FileImages { get; set; }
    }
}
