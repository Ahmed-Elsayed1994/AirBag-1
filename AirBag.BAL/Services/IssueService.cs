﻿using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Framework.Helpers;

namespace User.BAL.Services
{
    public class IssueService : BaseService<Issue, IssueVm>, IIssueService
    {
        public IssueService(IRepository<Issue> repository , IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

      
    }
}
