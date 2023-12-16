using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SolarEnergy.DbContext;

namespace SolarEnergy.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var x = await _context.Set<TEntity>().SingleOrDefaultAsync();
            return x;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var x = await _context.Set<TEntity>().SingleOrDefaultAsync();
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }

        //public Task<T> UpdatePartialAsync<T>(T t)
        //{
        //    throw new NotImplementedException();
        //}
    }
    
}
