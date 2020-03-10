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
            var user = _userService.GetEntity(a => a.UserName == loginModel.UserName);
            if (user != null)
                if (_utility.Verify(loginModel.Password, user.HashedPassword))
                    return user;
            return null;
        }

        public string GenerateOTP(string phoneNumber)
        {
            string numbers = "1234567890";
            string characters = numbers;
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
}
