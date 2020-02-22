using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : BaseAPIController<IIssueService, Issue, IssueVm>
    {
        public IssueController(IIssueService Service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, Service)
        {
        }
    }



}
