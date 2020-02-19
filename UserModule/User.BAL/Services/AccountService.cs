using Framework.Core.Model;
using Framework.Core.UOW;
using Framework.Helpers;
using System;
using User.BAL.Models;

namespace User.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUsersService _userService;
        internal readonly IUnitOfWork _unitOfWork;
        private readonly IUtility _utility;

        public AccountService(IUsersService usersService,
            IUnitOfWork unitOfWork,
            IUtility utility)
        {
            _userService = usersService;
            _unitOfWork = unitOfWork;
            _utility = utility;
        }
        public void Register(UserVM model)
        {
            try
            {
                _userService.Insert(model);
            }
            catch(Exception e)
            {
                _unitOfWork.SaveResult.Errors.Add(new Error(500,  e.Message.ToString()));
            }
        }

        public CoreData.Users.Entities.User Login(LoginVm loginModel)
        {
            return _userService.GetEntity(a => a.UserName == loginModel.UserName && _utility.Verify(loginModel.Password, a.HashedPassword));
        }
    }
}
