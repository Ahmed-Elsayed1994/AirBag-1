using Framework.Core;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;

namespace Persistence.Repositories
{
    public class UsersRepository : Repository<CoreData.Users.Entities.User>, IUsersRepository
    {
        public UsersRepository(ICtrlPlusDbContext context) : base(context)
        {
        }
    }
}
