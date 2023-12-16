using Domain.Models;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.DbContext;

namespace SolarEnergy.Services
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        new public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        new public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Set<Category>().SingleOrDefaultAsync(c => c.Id == id);
             _context.Remove(category);
            await _context.SaveChangesAsync();
            return  category;
        }
    }
}
