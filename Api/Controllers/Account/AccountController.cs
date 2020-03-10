using Api.Controllers.Base;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.BAL.Models;
using User.BAL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    public class AccountController : CommonController
    {
        private readonly IAccountService _accountService;
        private readonly IUtility _utility;
        private readonly TokenProvider _tokenProvider;
        private readonly IUnitOfWork _unitOfWork;


        public AccountController(IAccountService accountService,
            IUtility utility,
            TokenProvider tokenProvider,
            IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _utility = utility;
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM registerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrors(ModelState));
            _accountService.Register(registerVM);

            if (!CheckExistError())
               await _unitOfWork.Save();

            return _unitOfWork.SaveResult.Affected > 0 ? ResCreateOk(_unitOfWork.SaveResult) : ResCreateServerError(_unitOfWork.SaveResult);
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginVm loginModel)
        {
            var user = _accountService.Login(loginModel);
            if (user == null)
                return NotFound();
            var tokenVm = _tokenProvider.GenerateAccessToken(user);

            return Ok(new LoginResultVm(tokenVm));
        }

        [HttpPost]
        public void ForgetPassword()
        {

        }

        protected bool CheckExistError()
        {
            return _unitOfWork.SaveResult.Errors.Count != 0;
        }

        [HttpGet]
        public IActionResult GenerateOTP(string phoneNumber)
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
            return Ok(otp);
        }

        [HttpGet]
        public IActionResult VerifyOTP(string phoneNumber, string Code)
        {
            return Ok();
        }
    }
}
