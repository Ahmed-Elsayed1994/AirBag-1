using System;
using System.Collections.Generic;
using System.Text;
using User.BAL.Models;

namespace User.BAL.Services
{
    public interface IAccountService
    {
         void Register(UserVM model);
        CoreData.Users.Entities.User Login(LoginVm loginModel);
    }
}
