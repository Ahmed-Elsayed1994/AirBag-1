using Api.Controllers.Base;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register(UserVM registerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrors(ModelState));
            _accountService.Register(registerVM);

            if (!CheckExistError())
                _unitOfWork.Save();

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
    }
}
