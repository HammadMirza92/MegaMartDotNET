using MegaMart.AppDbContext;
using MegaMart.Entity;
using MegaMart.Repo.IRepository;
using MegaMart.Repo.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Repo.Repository
{
    public class productRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public productRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Product>> GetAll()
        {
            var allProducts = await _context.Product
                .Include(x=> x.Variations).ThenInclude(a=> a.Options)
                .ToListAsync();

            return allProducts;
        }
    }
}
