using MegaMart.AppDbContext;
using MegaMart.Entity;
using MegaMart.Repo.IRepository;
using MegaMart.Repo.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Repo.Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Get User By Email
        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Email == email).FirstOrDefaultAsync();

            return user;
        }

        // Get User By Id
        public async Task<ApplicationUser> GetById(string id)
        {
            var appuser = await _context.ApplicationUsers.FindAsync(id);
            return appuser;
        }
    }
}
