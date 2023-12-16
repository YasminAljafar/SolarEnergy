using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public decimal Price { get; set; }
        //multiple images
        public Category? Category { get; set; }
       // public string? ImagePath { get; set; }


        //  public List<Image>? FileImages { get; set; }

    }
}
