using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : BaseAPIController<ICardService, Card, CardVm>
    {
        public CardController(ICardService cardService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, cardService)
        {
        }
    }



}
