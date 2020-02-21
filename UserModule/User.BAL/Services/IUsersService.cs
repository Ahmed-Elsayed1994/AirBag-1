using CoreData.Users.Entities;
using Framework.Core.UOW;
using System.Collections;
using System.Collections.Generic;
using User.BAL.Models;

namespace User.BAL.Services
{
    public interface IUsersService : IBaseService<CoreData.Users.Entities.User, UserVM>
    {
        UserManagementVM GetCreateUserPageInfo();
        IList<int> GetAdminUserIds();
        IList<CoreData.Users.Entities.User> GetUsersByIds(IList<int> userIds);
    }
}
