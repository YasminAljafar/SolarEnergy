using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public IFormFile? ImagePath { get; set; }
    }
}