using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using User.BAL.Models;

namespace User.BAL.Services
{
    public class UsersService : BaseService<CoreData.Users.Entities.User, UserVM>, IUsersService
    {
        private readonly IUtility _utility;
        private readonly IRoleService _roleService;

        //protected override Func<CoreData.Users.Entities.User, IVM> FuncToVM()
        //{
        //    return (s) => new UserVM
        //    {
        //        Id = s.Id,
        //        Email = s.Email,
        //        UserName = s.UserName,
        //        Passowrd = s.HashedPassword
        //    };
        //}

        public UsersService(IUsersRepository usersRepository, IUtility utility, IUnitOfWork unitOfWork,
            IRoleService roleService, IMapper mapper
            )
            : base(usersRepository, unitOfWork, mapper)
        {
            _utility = utility;
            _roleService = roleService;
        }

        public override UserVM MapEntityToModel(CoreData.Users.Entities.User entity)
        {
            if (entity == null)
                return null;
            return new BaseUser
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
            };
        }
        public override CoreData.Users.Entities.User MapModelToEntity(UserVM model)
        {
            var user = base.MapModelToEntity(model);
            user.HashedPassword = model.Password != null || model.Password ==""? null: _utility.Hash(model.Password);
            return user;
        }

        //public override CoreData.Users.Entities.User MapModelToEntity(UserVM model)
        //{
        //    //  var UserRoles = new List<UserRole>();

        //    if (model == null)
        //    {
        //        AddError(500, "Model is null");
        //        return null;
        //    }
        //    var usr = _repository.GetById(model.Id);
        //    if (usr == null) // insert new user
        //    {
        //        var user = new CoreData.Users.Entities.User()
        //        {
        //            Email = model.Email,
        //            HashedPassword = _utility.Hash(model.Passowrd),
        //            UserName = model.UserName,

        //        };

        //        return user;
        //    }
        //    else
        //    {
        //        usr.Id = model.Id;
        //        usr.UserName = model.UserName;
        //        usr.Email = model.Email;

        //        return usr;
        //    }
        //}

        private IList<UserRole> GetUserRoleList(IList<Role> Units, CoreData.Users.Entities.User CurrentUser)
        {
            var userUnits = new List<UserRole>();
            foreach (var item in Units)
            {
                userUnits.Add(new UserRole()
                {
                    User = CurrentUser,
                    Role = item
                });
            }
            return userUnits;
        }

        //protected override void ValidateDelete(UserVM model)
        //{
        //    var match = _repository.GetById(model.Id);
        //    if (match == null)
        //        AddError(CommonErrors.NOT_FOUND);
        //}

        protected override void ValidateInsert(UserVM model)
        {
            var exist = _repository.Single(s => s.UserName == model.UserName || s.Email == model.Email || s.Id == model.Id);
            if (exist != null)
                AddError(CommonErrors.ALREADY_EXIST);
        }

        protected override void ValidateUpdate(UserVM model)
        {
            var match = _repository.GetById(model.Id);
            if (match == null)
                AddError(CommonErrors.NOT_FOUND);

            var exist = _repository.Single(s => s.Id != model.Id && s.UserName == model.UserName);
            if (exist != null)
                AddError(CommonErrors.ALREADY_EXIST);
        }
        public UserManagementVM GetCreateUserPageInfo()
        {
            var usr = _repository.Table.ToList();
            var roles = _roleService.GetRoles();

            IList<UserVM> userVMs = new List<UserVM>();
            IList<RoleVm> roleVMs = new List<RoleVm>();

            foreach (var item in usr)
            {
                userVMs.Add(MapEntityToModel(item));
            }
            foreach (var item in roles)
            {
                roleVMs.Add(new RoleVm()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return new UserManagementVM()
            {
                UserVMs = userVMs,
                RoleVms = roleVMs
            };
        }

        public override IList<SelectListItem> GetRequiredCreateModel()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Key = "Countries",
                Values = _unitOfWork.Country.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });

            items.Add(new SelectListItem()
            {
                Key = "Nationality",
                Values = _unitOfWork.Nationality.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });
            items.Add(new SelectListItem()
            {
                Key = "CountryCodes",
                Values = _unitOfWork.MobileCountryCode.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });

            return null;
        }

        public IList<int> GetAdminUserIds()
        {
            return _repository.Where(a => a.UserRoles.Any(b=> b.Role.Id == 3)).Select(c=> c.Id).ToList();
        }

        public IList<CoreData.Users.Entities.User> GetUsersByIds(IList<int> userIds)
        {
            if (userIds == null || userIds.Count == 0)
                return null;

            return _repository.Table.Where(a => userIds.Contains(a.Id)).ToList();
        }
    }
}
