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


        public ProductRepositoy(ApplicationDbContext context) : base(context)
        {
            _context = context;
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

        
    }
}
