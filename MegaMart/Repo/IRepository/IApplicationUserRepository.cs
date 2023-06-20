using MegaMart.Entity;
using MegaMart.Repo.IRepository.Base;

namespace MegaMart.Repo.IRepository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> FindUserByEmail(string email);
        Task<ApplicationUser> GetById(string id);
    }
}
