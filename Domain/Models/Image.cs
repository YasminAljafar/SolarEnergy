using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
    }
}