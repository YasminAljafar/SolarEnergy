using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.DbContext;
using SolarEnergy.Dtos;
using SolarEnergy.ViewModel;

namespace SolarEnergy.Services
{
    public class ProductRepositoy : GenericRepository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductRepositoy(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        new public async Task AddAsync(ProductCreateDto product)
        {

            //foreach (var item in product.FileImages)
            //{
            //    string stringFileName = SaveFile(item);
            //    var image = new Image
            //    {
            //        ImagePath = stringFileName
            //    };
            //    _context.Images.Add(image);
            //    _context.SaveChanges();
            //}
            string PdfFile = SaveFile(product.FilePath);
            var newProduct = new Product()
            {
                FilePath = PdfFile
            };
            //await _context.Products.AddAsync(newProduct);
            //await _context.SaveChangesAsync();

            //await _context.Products.AddAsync(newProduct);
            //await _context.SaveChangesAsync();

            //return newProduct;
        }

        new public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().Include(p=>p.Category).ToListAsync();
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

        public string SaveFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDirection = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDirection, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                }

            }
            return fileName;
        }
    }
}
