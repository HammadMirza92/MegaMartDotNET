using MegaMart.AppDbContext;
using MegaMart.Entity;
using MegaMart.Repo.IRepository;
using MegaMart.Repo.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Repo.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Category>> GetAll()
        {
            var allCategories = await _context.Categories
                .Include(x => x.Products)
                .ToListAsync();

            return allCategories;
        }
    }
}
