using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.DbContext;
using SolarEnergy.Dtos;
using SolarEnergy.Profiles;
using SolarEnergy.ViewModel;

namespace SolarEnergy.Services
{
    public class ProductRepositoy : GenericRepository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;



        public ProductRepositoy(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        new public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().Include(p=>p.Category).ToListAsync();
        }
        new public async Task<Product> AddAsync(ProductCreateDto product)
        {
            var newProduct = _mapper.Map<ProductCreateDto, Product>(product);
         
            foreach (var image in product.Files)
            {
                string url = UploadFile(image);
                newProduct.Images.Add(new Image
                {
                   ImagePath = url,
                   ProductId = product.Id,
                });         
                //var img = new Image
                //{
                //    ImagePath = url,
                //    ProductId = product.Id,      
                //};
                //await _context.Images.AddAsync(img);
                //await _context.SaveChangesAsync();
            }
            await  _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }
        new public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(_=>_.Category).SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        new public async Task<Product> DeleteAsync(int id)
        {
            var product= await _context.Set<Product>().SingleOrDefaultAsync(p => p.Id == id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        private string UploadFile(IFormFile file)
        {
            string url = string.Empty;
            if (file?.Length > 0)
            {
                var path = _webHostEnvironment.WebRootPath + "\\" + "Uploads\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    url = _webHostEnvironment.WebRootPath.Replace("\\", "/") + "/Uploads/" + file.FileName;
                }

            }
            return url;
        }
    }
}
