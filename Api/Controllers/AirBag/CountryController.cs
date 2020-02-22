using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseAPIController<ICountryService, Country, CountryVm>
    {
        public CountryController(ICountryService countryService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, countryService)
        {
        }
    }



}
