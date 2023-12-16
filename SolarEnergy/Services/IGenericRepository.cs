namespace SolarEnergy.Services
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task AddAsync(TEntity entity);
        public Task<bool> UpdateAsync(TEntity entity);
        //public Task<T> UpdatePartialAsync<T>(T t);
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public Task<TEntity> DeleteAsync(int id);

    }
}
