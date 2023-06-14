using MegaMart.AppDbContext;
using MegaMart.Repo.IRepository.Base;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Repo.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async virtual Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async virtual Task<T> GetById(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            var existingEntity = _context.Set<T>().Local.FirstOrDefault();
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
